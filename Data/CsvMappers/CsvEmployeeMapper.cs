using PacsTest.Data.Entities;

namespace PacsTest.Data.CsvMappers;

public class CsvEmployeeMapper : CsvHelper.Configuration.ClassMap<Employee>
{
    public CsvEmployeeMapper()
    {
        Map(c => c.EmployeeId).Name("EmployeeID");
        Map(c => c.FirstName).Name("FirstName");
        Map(c => c.LastName).Name("LastName");
    }
}
