using Microsoft.EntityFrameworkCore;

namespace Lab07.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext():base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string str = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=Northwind;uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(str);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>()
                .HasOne<Categories>(c => c.Categories)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => fk.CategoryID);
        }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
    }
}
