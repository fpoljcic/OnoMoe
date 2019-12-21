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
    }
}
