using Lab03.Models;

namespace Lab03.Repository
{
    public interface EmployeeServices
    {
        List<Employee> GetEmployees();
        List<Employee> GetEmployees(string name);
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int id);
        void saveEmployee(Employee employee);
        void updateEmployee(Employee employee);
    }
}
