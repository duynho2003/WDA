using Lab07.Models;

namespace Lab07.Services
{
    public class CategoriesServices : Repository.CategoriesRepository
    {
        private DatabaseContext _db;
        public CategoriesServices(DatabaseContext db)
        {
            _db = db; 
        }
        public void AddCategory(Categories category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public List<Categories> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
