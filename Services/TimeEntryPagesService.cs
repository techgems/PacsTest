using PacsTest.ComponentTagHelpers;
using PacsTest.Data.Entities;
using PacsTest.Data.Repositories.Interfaces;
using PacsTest.Models;
using PacsTest.Services.Interfaces;

namespace PacsTest.Services;

public class TimeEntryPagesService : ITimeEntryPageService
{
    private readonly ITimeEntryRepository _timeEntryRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public TimeEntryPagesService(ITimeEntryRepository timeEntryRepository, IEmployeeRepository employeeRepository)
    {
        _timeEntryRepository = timeEntryRepository;
        _employeeRepository = employeeRepository;
    }

    public List<EmployeeFilterModel> GetEmployeesForFilter()
    {
        var employees = _employeeRepository.GetAllEmployees();

        var filterList = employees.Select(e => new EmployeeFilterModel
        {
            EmployeeId = e.EmployeeId,
            FullName = GetEmployeeFullname(e)
        }).ToList();

        return filterList;
    }

    public TimeEntryViewModel GetTimeEntriesForEmployees(int? employeeId = null, DateOnly? entryDate = null)
    {
        var timeEntries = _timeEntryRepository.GetAllTimeEntries();
        var employees = _employeeRepository.GetAllEmployees();

        var viewModels = timeEntries.Where(x => { 
        
            var matchesEmployee = !employeeId.HasValue || x.EmployeeId == employeeId.Value;
            var matchesDate = !entryDate.HasValue || x.Date == entryDate.Value;
            return matchesEmployee && matchesDate;

        }).Select(x => {

            var employee = employees.FirstOrDefault(e => e.EmployeeId == x.EmployeeId);

            return new TimeEntryModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeFullname = GetEmployeeFullname(employee),
                Date = x.Date,
                InTime = x.InTime,
                OutTime = x.OutTime
            };
        });

        var timeEntryViewModel = new TimeEntryViewModel
        {
            EntriesList = viewModels.ToList(),
            EmployeeFilterList = employees.Select(e => new EmployeeFilterModel
            {
                EmployeeId = e.EmployeeId,
                FullName = GetEmployeeFullname(e)
            }).ToList(),
            DateFilterList = timeEntries.Select(te => te.Date).Distinct().ToList()
        };

        if (employeeId is not null)
        {
            timeEntryViewModel.SelectedEmployeeFilter = timeEntryViewModel.EmployeeFilterList.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
        }

        if (entryDate is not null)
        {
            timeEntryViewModel.SelectedDateFilter = timeEntryViewModel.DateFilterList.Where(x => x == entryDate).FirstOrDefault();
        }

        return timeEntryViewModel;
    }

    public bool InsertTimeEntry(TimeEntryFormComponent model) 
    {
        try 
        {
            var lastTimeEntry = _timeEntryRepository.GetAllTimeEntries().OrderBy(x => x.TimeEntryId).Last();

            _timeEntryRepository.InsertTimeEntry(new TimeEntry
            {
                TimeEntryId = lastTimeEntry.TimeEntryId + 1,
                EmployeeId = model.EmployeeId,
                Date = model.Date!.Value,
                InTime = model.InTime!.Value,
                OutTime = model.OutTime!.Value
            });
        }
        catch(Exception e)
        {
            return false;
        }

        return true;


    }

    private string GetEmployeeFullname(Employee employee)
    {
        return employee != null ? $"{employee.FirstName} {employee.LastName}" : "Unknown Employee";
    }
}
