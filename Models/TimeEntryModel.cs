namespace PacsTest.Models;

public class TimeEntryModel
{
    public int EmployeeId { get; set; }
    public string EmployeeFullname { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly InTime { get; set; }
    public TimeOnly OutTime { get; set; }
    public TimeSpan Duration => OutTime - InTime;
}
