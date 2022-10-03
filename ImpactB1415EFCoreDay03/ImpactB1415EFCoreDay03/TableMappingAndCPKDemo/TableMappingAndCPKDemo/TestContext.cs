using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TableMappingAndCPKDemo
{
    public class TestContext:DbContext
    {
        public TestContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=IMCCBCP52-MSL2\\SQLEXPRESS2019;Initial Catalog=ImpactB13CodeFirst;User ID=sa;Password=password_123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeProject>().
                HasKey(e => new { e.EmployeeId, e.ProjectId });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    }
}
