using Lab04.Areas.Departments.Models;
using Lab04.Areas.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Areas.Departments.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity => {
                entity.HasOne(d => d.Department)
                    .WithMany(e => e.Employee)
                    .HasForeignKey(d => d.No)
                    .HasConstraintName("fk_Department_Employee");
            });
        }
    }
}
