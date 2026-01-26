using PacsTest.Data.Entities;

namespace PacsTest.Data.CsvMappers;

public class CsvTimeEntryMapper : CsvHelper.Configuration.ClassMap<TimeEntry>
{
    public CsvTimeEntryMapper()
    {
        Map(c => c.TimeEntryId).Name("EntryID");
        Map(c => c.EmployeeId).Name("EmployeeID");
        Map(c => c.Date).Name("Date");
        Map(c => c.InTime).Name("InTime");
        Map(c => c.OutTime).Name("OutTime");
    }
}
