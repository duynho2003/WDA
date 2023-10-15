using Pretest3.Models;

namespace Pretest3.Repository
{
    public interface UsersRepository
    {
        List<TbUser> FindAll();
        void AddUser(TbUser addUser);
        TbUser checkLogin(string UserId, string PassWord);
        TbUser FindOne(string UserId);
    }
}
