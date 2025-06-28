using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Models;

public partial class EmployeeManagementDbContext : DbContext
{
    public EmployeeManagementDbContext()
    {
    }

    public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeDb> EmployeeDbs { get; set; }

    public virtual DbSet<UsersDb> UsersDbs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDb>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11BBB10F88");

            entity.ToTable("EmployeeDb");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(110);
            entity.Property(e => e.Email).HasMaxLength(110);
            entity.Property(e => e.EmployeeName).HasMaxLength(110);
            entity.Property(e => e.Position).HasMaxLength(110);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<UsersDb>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UsersDb__1788CC4CC4A33682");

            entity.ToTable("UsersDb");

            entity.HasIndex(e => e.Email, "UQ__UsersDb__A9D10534D6308F65").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__UsersDb__C9F284567DB2F452").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(110);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("User");
            entity.Property(e => e.UserName).HasMaxLength(110);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
