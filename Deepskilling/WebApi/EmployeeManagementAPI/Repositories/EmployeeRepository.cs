using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new();
    private int _nextId = 1;

    public EmployeeRepository()
    {
        // seed
        Create(new Employee { FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com", Department = "Engineering" });
        Create(new Employee { FirstName = "Bob", LastName = "Smith", Email = "bob@example.com", Department = "HR" });
        Create(new Employee { FirstName = "Charlie", LastName = "Brown", Email = "charlie@example.com", Department = "Finance" });
    }

    public IEnumerable<Employee> GetAll() => _employees.OrderBy(e => e.Id).ToList();

    public Employee? GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

    public Employee Create(Employee employee)
    {
        employee.Id = _nextId++;
        _employees.Add(employee);
        return employee;
    }

    public Employee? Update(int id, Employee employee)
    {
        var existing = _employees.FirstOrDefault(e => e.Id == id);
        if (existing is null) return null;

        existing.FirstName = employee.FirstName;
        existing.LastName = employee.LastName;
        existing.Email = employee.Email;
        existing.Department = employee.Department;

        return existing;
    }

    public bool Delete(int id)
    {
        var existing = _employees.FirstOrDefault(e => e.Id == id);
        if (existing is null) return false;
        _employees.Remove(existing);
        return true;
    }
}
