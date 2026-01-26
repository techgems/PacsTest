namespace PacsTest.Models;

public class TimeEntryViewModel
{
    public List<TimeEntryModel> EntriesList { get; set; } = new();

    public List<EmployeeFilterModel> EmployeeFilterList { get; set; } = new();

    public List<DateOnly> DateFilterList { get; set; } = new();

    public EmployeeFilterModel? SelectedEmployeeFilter { get; set; }

    public DateOnly? SelectedDateFilter { get; set; }
}
