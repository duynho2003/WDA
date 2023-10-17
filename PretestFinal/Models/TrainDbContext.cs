using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PretestFinal.Models;

public partial class TrainDbContext : DbContext
{
    public TrainDbContext()
    {
    }

    public TrainDbContext(DbContextOptions<TrainDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbProfile> TbProfiles { get; set; }

    public virtual DbSet<TbTrainer> TbTrainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;Database=TrainDB;uid=sa;pwd=123;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbProfil__3213E83F63587870");

            entity.ToTable("tbProfile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Placeofbirth)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("placeofbirth");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Skills)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("skills");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TbProfiles)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__tbProfile__usern__3B75D760");
        });

        modelBuilder.Entity<TbTrainer>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__tbTraine__F3DBC573B7F565E9");

            entity.ToTable("tbTrainer");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Roles).HasColumnName("roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
