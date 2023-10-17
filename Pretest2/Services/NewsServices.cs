using Pretext2.Models;
using Pretext2.Repository;

namespace Pretext2.Services
{
    public class NewsServices : NewsRepository
    {
        private DatabaseContext _db;
        public NewsServices(DatabaseContext db)
        {
            _db = db;
        }

        public void AddNew(News addnew)
        {
            _db.News.Add(addnew);
            _db.SaveChanges();
        }

        public Infos checkLogin(string username, string password)
        {
            var infos = _db.Infos.SingleOrDefault(d => d.UserName == username);
            if (infos != null)
            {
                if (infos.Password == password)
                {
                    return infos;
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

        public void Delete(int id)
        {
            var news = _db.News.SingleOrDefault(d => d.NewsId == id);
            if(news != null) 
            { 
                _db.News.Remove(news);
                _db.SaveChanges();
            }
        }

        public List<News> FindAll()
        {
            return _db.News.ToList();
        }
    }
}
