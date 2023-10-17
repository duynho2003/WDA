using Microsoft.EntityFrameworkCore;

namespace Pretext2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=News;uid=sa;pwd=123;TrustServerCertificate=true;");
        }

        public DbSet<News> News { get; set; }
        public DbSet<Infos> Infos { get; set; }
    }
}
