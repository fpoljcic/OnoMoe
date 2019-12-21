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
            base.OnModelCreating( modelBuilder );


        }

        public List<Voznja> dajVoznje(string datum, string vrijeme)
        {
            DateTime dateTime = new DateTime(Convert.ToInt32(datum.Substring(0, datum.IndexOf("-"))), Convert.ToInt32(datum.Substring(datum.IndexOf("-") + 1, datum.Length - datum.LastIndexOf("-") - 1)), Convert.ToInt32(datum.Substring(datum.LastIndexOf("-") + 1)));

            //List<Voznja> voznje = Voznja.Where((Voznja voznja) => voznja.VrijemePolaska.Date.Equals(dateTime.Date) && voznja.VrijemePolaska.TimeOfDay.CompareTo(new DateTime(vrijeme).TimeOfDay) >= 0 ).ToList();
            //reservations.Sort((Reservation a, Reservation b) => DateTime.Compare(a.DateTime, b.DateTime));
            //return reservations;
            return null;
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
                voznje.Add(m.Voznja);
            }
            return voznje;
        }
    }
}
