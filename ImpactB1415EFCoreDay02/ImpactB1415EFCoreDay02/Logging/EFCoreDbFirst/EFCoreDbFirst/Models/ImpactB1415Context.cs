using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace EFCoreDbFirst.Models
{
    public partial class ImpactB1415Context : DbContext
    {
        public ImpactB1415Context()
        {
        }

        public ImpactB1415Context(DbContextOptions<ImpactB1415Context> options)
            : base(options)
        {
        }

        public static readonly ILoggerFactory loggerFactory
          = LoggerFactory.Create(builder =>
          {
              builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                //.AddConsole();
                .AddConsole(configure => configure.TimestampFormat = "[dd/MM/yy HH:mm:ss:fff] ");
          });

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)/*.EnableSensitiveDataLogging()*/
                    .UseSqlServer("Data Source=IMCCBCP52-MSL2\\SQLEXPRESS2019;Initial Catalog=ImpactB1415;User ID=sa;Password=password_123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Employees__Depar__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
