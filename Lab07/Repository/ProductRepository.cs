using Lab07.Models;

namespace Lab07.Repository
{
    public interface ProductRepository
    {
        List<Products> findAll();
        Products findById(int id);
        void save (Products product);
        void update (Products product);
        void delete (int id);
    }
}
