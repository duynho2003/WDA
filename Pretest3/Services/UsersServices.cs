using Pretest3.Models;
using Pretest3.Repository;

namespace Pretest3.Services
{
    public class UsersServices : UsersRepository
    {
        private UserDbContext _db;
        public UsersServices(UserDbContext db)
        {
            _db = db;
        }

        public void AddUser(TbUser addUser)
        {
           _db.TbUsers.Add(addUser);
            _db.SaveChanges();
        }

        public TbUser checkLogin(string id, string pass)
        {
            var user = _db.TbUsers.Find(id);
            if (user != null) 
            {
                if (user.PassWord == pass)
                {
                    return user;
                }
                else 
                {
                    return null!;
                }
            }
            else { return null!; }
        }

        public List<TbUser> FindAll()
        {
            return _db.TbUsers.ToList();
        }

        public TbUser FindOne(string id)
        {
            var users = _db.TbUsers.Find(id);
            if (users != null)
            {
                return users;
            }
            else
            {
                return null!;
            }
        }
    }
}
