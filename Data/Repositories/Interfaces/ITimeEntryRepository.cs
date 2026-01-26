using PacsTest.Data.Entities;

namespace PacsTest.Data.Repositories.Interfaces;

public interface ITimeEntryRepository
{
    public List<TimeEntry> GetAllTimeEntries();

    bool InsertTimeEntry(TimeEntry timeEntry);
}
