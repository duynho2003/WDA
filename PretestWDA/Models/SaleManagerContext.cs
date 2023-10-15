using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PretestWDA.Models;

public partial class SaleManagerContext : DbContext
{
    public SaleManagerContext()
    {
    }

    public SaleManagerContext(DbContextOptions<SaleManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbEmployee> TbEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=SaleManager;uid=sa;pwd=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbEmployee>(entity =>
        {
            entity
                
                .ToTable("tbEmployee");

            entity.Property(e => e.EmpAddress)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmpDob).HasColumnType("datetime");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
