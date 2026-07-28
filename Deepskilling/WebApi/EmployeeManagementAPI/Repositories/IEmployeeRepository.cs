using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
    Employee? GetById(int id);
    Employee Create(Employee employee);
    Employee? Update(int id, Employee employee);
    bool Delete(int id);
}
