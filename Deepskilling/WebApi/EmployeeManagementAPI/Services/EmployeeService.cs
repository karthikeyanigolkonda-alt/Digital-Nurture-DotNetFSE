using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;

namespace EmployeeManagementAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Employee> GetAll() => _repository.GetAll();

    public Employee? GetById(int id) => _repository.GetById(id);

    public Employee Create(Employee employee) => _repository.Create(employee);

    public Employee? Update(int id, Employee employee) => _repository.Update(id, employee);

    public bool Delete(int id) => _repository.Delete(id);
}
