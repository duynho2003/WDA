using Lab07.Models;

namespace Lab07.Services
{
    public class ProductServices : Repository.ProductRepository
    {
        private DatabaseContext _db;
        public ProductServices(DatabaseContext db)
        {
            _db = db;
        }
        public void delete(int id)
        {
            var product=_db.Products.FirstOrDefault(p=>p.ProductID==id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            else
            {
                //nothing
            }
        }

        public List<Products> findAll()
        {
            return _db.Products.ToList();
        }

        public Products findById(int id)
        {
            var products = _db.Products.FirstOrDefault(x=>x.ProductID==id);
            return products!;
        }

        public void save(Products product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void update(Products product)
        {
            var pro = _db.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (pro != null)
            {
                pro.Price=product.Price;
                _db.SaveChanges();
            }
        }
    }
}
