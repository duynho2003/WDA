using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab06Domain.Models;
namespace Lab06Infrastructure.Repository
{
    public interface CustomerRepository
    {
        List<Customer> findAll();
        Customer findOne(string code);
        Customer checkLogin(string code, string password);
    }
}
