using Algorithms_Final_V.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms_Final_V.Data
{
    public class FactionContext : DbContext
    {
        public FactionContext(DbContextOptions<FactionContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Initiate> Initiates { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<StationedLocation> StationedLocations { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Initiate>().ToTable("Initiate");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Officer>().ToTable("Officer");
            modelBuilder.Entity<StationedLocation>().ToTable("StaionedLocation");
            modelBuilder.Entity<RoleAssignment>().ToTable("RoleAssignment");

            modelBuilder.Entity<RoleAssignment>()
                .HasKey(c => new { c.RoleID, c.OfficerID });
        }
    }
}
