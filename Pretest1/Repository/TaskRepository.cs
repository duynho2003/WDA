using Pretest1.Models;

namespace Pretest1.Repository
{
    public interface TaskRepository
    {
        Employee CheckLogin(string empID, string empPass);

        void AddTask(TaskSheet task);

        void DeleteTask(int id);
        List<TaskSheet> FindAll();
    }
}
