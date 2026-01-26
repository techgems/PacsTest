using PacsTest.Data.Entities;

namespace PacsTest.Data.Repositories.Interfaces;

public interface IEmployeeRepository
{
    public List<Employee> GetAllEmployees();
}
