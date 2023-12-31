﻿using Microsoft.EntityFrameworkCore;

namespace Lab03.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext():base() { }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string str = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=EmployeeDB;uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(str);
        }
    }
}
