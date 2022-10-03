using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationships.Models
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-BB28HAA\SQLEXPRESS;Initial Catalog=EFRelationships;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);
            modelBuilder.Entity<Employee>()
                .HasOne<EmployeeAddress>(p=>p.EmployeeAddress)
                .WithOne(s=>s.Employee)
                .HasForeignKey<EmployeeAddress>(s=>s.EmployeeId);
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(d => d.Department)
                .WithMany(emp => emp.DeptEmployees)
                .HasForeignKey(t => t.DepartmentId);
            modelBuilder.Entity<EmployeesInProject>()
            .HasKey(e => new { e.EmployeeId, e.ProjectId });
            modelBuilder.Entity<EmployeesInProject>()
            .HasOne<Employee>(e => e.Employee)
            .WithMany(p => p.EmployeesInProject);
            modelBuilder.Entity<EmployeesInProject>()
            .HasOne<Project>(e => e.Project)
            .WithMany(p => p.EmployeesInProject);


        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeesInProject> EmployeesInProjects { get; set; }
    }
}
