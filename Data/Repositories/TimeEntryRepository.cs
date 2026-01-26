using CsvHelper;
using CsvHelper.Configuration;
using PacsTest.Data.CsvMappers;
using PacsTest.Data.Entities;
using PacsTest.Data.Repositories.Interfaces;
using System.Globalization;

namespace PacsTest.Data.Repositories;

public class TimeEntryRepository : ITimeEntryRepository
{
    public List<TimeEntry> GetAllTimeEntries()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };

        using var reader = new StreamReader("Data/CSV/TimeEntries.csv");
        using var csv = new CsvReader(reader, config);

        csv.Context.RegisterClassMap<CsvTimeEntryMapper>();

        var records = csv.GetRecords<TimeEntry>().ToList();
        return records;
    }

    public bool InsertTimeEntry(TimeEntry timeEntry)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
        };

        using (var stream = File.Open("Data/CSV/TimeEntries.csv", FileMode.Append))
        using (var writer = new StreamWriter(stream))
        using (var csv = new CsvWriter(writer, config))
        {
            csv.WriteRecord(timeEntry);
        }

        return true;
    }
}
