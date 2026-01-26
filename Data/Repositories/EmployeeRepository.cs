using CsvHelper;
using CsvHelper.Configuration;
using PacsTest.Data.CsvMappers;
using PacsTest.Data.Entities;
using PacsTest.Data.Repositories.Interfaces;
using System.Globalization;

namespace PacsTest.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    public List<Employee> GetAllEmployees()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };

        using var reader = new StreamReader("Data/CSV/Employees.csv");
        using var csv = new CsvReader(reader, config);

        csv.Context.RegisterClassMap<CsvEmployeeMapper>();

        var records = csv.GetRecords<Employee>().ToList();
        return records;
    }
}
