using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentLife.Models {
    public class DatabaseContext : DbContext {
        public DatabaseContext() : base()
        {

        }

        public DatabaseContext( DbContextOptions<DatabaseContext> options )
            : base( options )
        { }

        public DbSet<Nagrade> Nagrade { get; set; }
        public DbSet<Student> Student { get; set; }

        public DbSet<Voznja> Voznja { get; set; }

        public DbSet<Marker> Marker { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer( "Server=tcp:sjedibalfp.database.windows.net,1433;Initial Catalog=SjediBa;Persist Security Info=False;User ID=lanajurcevic1;Password=Ljeto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" );
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Voznja>().ToTable( "Voznja" );
            modelBuilder.Entity<Marker>().ToTable( "Marker" );
            modelBuilder.Entity<Nagrade>().ToTable( "Nagrade" );
            base.OnModelCreating( modelBuilder );


        }

        public Student dajStudenta(int id)
        {
            return Student.Where((Student student) => student.StudentID == id).FirstOrDefault();
        }

        public Marker dajMarker(int studentID,int voznjaID)
        {
            return Marker.Where((Marker marker) => marker.StudentID == studentID && marker.VoznjaID ==voznjaID).FirstOrDefault();
        }

        public List<Voznja> dajVoznje(string datum, string vrijeme)
        {
            DateTime dateTime = new DateTime(Convert.ToInt32(datum.Substring(0, datum.IndexOf("-"))), Convert.ToInt32(datum.Substring(datum.IndexOf("-") + 1, datum.Length - datum.LastIndexOf("-") - 1)), Convert.ToInt32(datum.Substring(datum.LastIndexOf("-") + 1)));
            DateTime dateTime2 = new DateTime(2019, 12, 21, Convert.ToInt32(vrijeme.Substring(0, vrijeme.IndexOf(":"))), Convert.ToInt32(vrijeme.Substring(vrijeme.IndexOf(":") + 1, vrijeme.Length - vrijeme.LastIndexOf(":") - 1)), 0);

            List<Voznja> voznje = Voznja.Where((Voznja voznja) => voznja.VrijemePolaska.Date.Equals(dateTime.Date) && voznja.VrijemePolaska.TimeOfDay.CompareTo(dateTime2.TimeOfDay) >= 0 ).ToList();
            voznje.Sort((Voznja a, Voznja b) => DateTime.Compare(a.VrijemePolaska, b.VrijemePolaska));
            return voznje;
        }

        public List<Voznja> MojePonudjeneVoznje(int trenutniUserID)
        {
            return Voznja.Where(voznja => voznja.StudentID == trenutniUserID).ToList();
        }

        public List<Voznja> MojeTrazeneVoznje(int trenutniUserID)
        {
            List<Marker> markeri = Marker.Where(marker => marker.StudentID == trenutniUserID).ToList();
            List<Voznja> voznje = new List<Voznja>();
            foreach (Marker m in markeri)
            {
                Voznja v = Voznja.Where(voznja => voznja.VoznjaID == m.VoznjaID).FirstOrDefault();
                voznje.Add(v);
            }
            return voznje;
        }
    }
}
