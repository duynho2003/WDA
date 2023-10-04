using Lab07.Models;

namespace Lab07.Repository
{
    public interface CategoriesRepository
    {
        List<Categories> GetCategories();
        void AddCategory(Categories category);
    }
}
