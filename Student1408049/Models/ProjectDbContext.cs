using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student1408049.Models;

public partial class ProjectDbContext : DbContext
{
    public ProjectDbContext()
    {
    }

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbProject> TbProjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;Database=ProjectDB;uid=sa;pwd=123;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbProjec__3214EC077E8FDFB0");

            entity.ToTable("tbProject");

            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
