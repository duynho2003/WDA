using Microsoft.EntityFrameworkCore;

namespace Lab02.Models
{
    public class DatabaseContext :  DbContext
    {
        public DatabaseContext(DbContextOptions options) :base(options){ }
        public DbSet<Student> Student { get; set; }
    }
}
