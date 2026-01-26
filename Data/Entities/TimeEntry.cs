namespace PacsTest.Data.Entities;

public class TimeEntry
{
    public int TimeEntryId { get; set; }
    public int EmployeeId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly InTime { get; set; }
    public TimeOnly OutTime { get; set; }
}
