using PacsTest.ComponentTagHelpers;
using PacsTest.Models;

namespace PacsTest.Services.Interfaces;

public interface ITimeEntryPageService
{
    TimeEntryViewModel GetTimeEntriesForEmployees(int? employeeId = null, DateOnly? entryDate = null);

    List<EmployeeFilterModel> GetEmployeesForFilter();

    bool InsertTimeEntry(TimeEntryFormComponent model);
}
