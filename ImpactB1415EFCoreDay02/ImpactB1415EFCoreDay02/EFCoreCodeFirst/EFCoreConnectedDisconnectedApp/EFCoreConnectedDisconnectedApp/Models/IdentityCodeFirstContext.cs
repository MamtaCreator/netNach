using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreConnectedDisconnectedApp.Models
{
    public partial class IdentityCodeFirstContext : DbContext
    {
        public IdentityCodeFirstContext()
        {
        }

        public IdentityCodeFirstContext(DbContextOptions<IdentityCodeFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Dept> Depts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=IMCCBCP52-MSL2\\SQLEXPRESS2019;Initial Catalog=IdentityCodeFirst;User ID=sa;Password=password_123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("Dept");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(75);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
