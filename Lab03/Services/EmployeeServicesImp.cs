using Lab03.Models;
using Lab03.Repository;

namespace Lab03.Services
{
    public class EmployeeServicesImp : EmployeeServices
    {
        private DatabaseContext _db;
        public EmployeeServicesImp(DatabaseContext db)
        {
            _db = db;
        }
        public void DeleteEmployee(int Id)
        {
            var emp = _db.Employee.SingleOrDefault(emp => emp.Id == Id);
            if (emp != null)
            {
                _db.Employee.Remove(emp);
                _db.SaveChanges();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _db.Employee.SingleOrDefault(employee => employee.Id == id);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return null!;
            }
        }

        public List<Employee> GetEmployees()
        {
            return _db.Employee.ToList();
        }

        public List<Employee> GetEmployees(string name)
        {
            var list = _db.Employee.ToList();
            if (name.Equals(""))
            {
                return list;
            }
            else
            {
                list = list.Where(e => e.Name!.Contains(name)).ToList();
                return list;
            }
        }

        public void saveEmployee(Employee employee)
        {
            _db.Employee.Add(employee);
            _db.SaveChanges();
        }

        public void updateEmployee(Employee employee)
        {
            var emp = _db.Employee.SingleOrDefault(e => e.Id.Equals(employee.Id));
            if (emp != null)
            {
                emp.Salary = employee.Salary;
                _db.SaveChanges();
            }

        }
    }
}
