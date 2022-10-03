using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPViewRawSqlCodeFirst.Models
{
    public class ImpactB1415Context:DbContext
    {
        public DbSet<EmployeeInfo> EmployeesInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=IMCCBCP52-MSL2\SQLEXPRESS2019;Initial Catalog=ImpactB1415;User ID=sa;Password=password_123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeInfo>()
                .ToView("EmployeesInfo")
                .HasKey("EmployeeId");
        }
    }
}
