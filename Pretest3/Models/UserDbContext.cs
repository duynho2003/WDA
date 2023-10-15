using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pretest3.Models;

public partial class UserDbContext : DbContext
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;Database=UserDB;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbUsers__1788CC4CD4F416B5");

            entity.ToTable("tbUsers");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PassWord)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
