using Pretext2.Models;

namespace Pretext2.Repository
{
    public interface NewsRepository
    {
        Infos checkLogin(string username, string password);
        List<News> FindAll();
        void AddNew(News addnew);
        void Delete(int id);
    }
}
