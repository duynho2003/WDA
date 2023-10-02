using Microsoft.EntityFrameworkCore;

namespace Lab05.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string ConnectDB = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=SchoolDB;uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(ConnectDB);
        }

        public DbSet<Course> Course { get; set; }
    }
}
