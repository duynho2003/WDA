using Pretest1.Models;
using Pretest1.Repository;

namespace Pretest1.Services
{
    public class TaskServices : TaskRepository
    {
        private TaskManagerContext _db;
        public TaskServices(TaskManagerContext db) { _db = db; }
        public void AddTask(TaskSheet task)
        {
            _db.TaskSheets.Add(task);
            _db.SaveChanges();
        }

        public Employee CheckLogin(string empID, string empPass)
        {
            var emp = _db.Employees.FirstOrDefault(e => e.EmpID == empID);
            if (emp != null)
            {
                if (emp.EmpPass == empPass)
                {
                    return emp;
                }
                else
                {
                    return null!;
                }
            }
            else { return null!; }
        }

        public void DeleteTask(int id)
        {
            var task = _db.TaskSheets.FirstOrDefault(t => t.TaskID == id);
            if (task != null)
            {
                _db.TaskSheets.Remove(task);
                _db.SaveChanges();
            }
        }

        public List<TaskSheet> FindAll()
        {
            return _db.TaskSheets.ToList();
        }
    }
}
