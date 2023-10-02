using Lab06Domain.Models;
using Lab06Domain.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab06Infrastructure.Services
{
    public class CustomerServices : Repository.CustomerRepository
    {
        private DatabaseContext _db;
        public CustomerServices(DatabaseContext db) 
        {
            _db = db;
        }
        public Customer checkLogin(string code, string password)
        {
            var customer = _db.Customer.SingleOrDefault(c=>c.code == code);
            if (customer != null) {
                if(customer.password == password) {
                 return customer;
                }
                else 
                {
                    return null!;
                }
            }
            else
            { 
                return null!; 
            }
        }

        public List<Customer> findAll()
        {
            var model = _db.Customer
                .Where(c=>c.role==false)
                .OrderBy(c=>c.balance)
                .ToList();
            // var model = (from c
            //                in _db.Customer
            //                where c.role == false
            //                select c).ToList();
            return model;
        }

        public Customer findOne(string code)
        {
            var customer = (from c 
                         in _db.Customer
                         where c.code == code
                         select c).FirstOrDefault();
            if (customer != null)
            {
                return customer!;
            }
            return customer!;
        }
    }
}