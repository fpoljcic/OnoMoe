using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentLife.Models {
    public class DatabaseContext : DbContext {
        public DbSet<Student> Student { get; set; }

        public DbSet<Voznja> Voznja { get; set; }

        public DbSet<Marker> Marker { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            base.OnConfiguring( optionsBuilder );
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
        }
    }
}
