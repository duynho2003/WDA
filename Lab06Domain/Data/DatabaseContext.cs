using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06Domain.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base() { }
        public DbSet<Models.Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectDB = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=BankDB;uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectDB);
        }
    }
}
