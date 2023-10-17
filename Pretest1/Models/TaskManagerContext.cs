using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pretest1.Models;

public partial class TaskManagerContext : DbContext
{
    public TaskManagerContext()
    {
    }

    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<TaskSheet> TaskSheets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;Database=TaskManager;uid=sa;pwd=123;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpID).HasName("PK__Employee__AF2DBA790070500E");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EmpID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmpPass)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaskSheet>(entity =>
        {
            entity.HasKey(e => e.TaskID).HasName("PK__TaskShee__7C6949D1A14F61E5");

            entity.ToTable("TaskSheet");

            entity.Property(e => e.TaskID).HasColumnName("TaskID");
            entity.Property(e => e.EmpID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EmpID");
            entity.Property(e => e.FinishTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
