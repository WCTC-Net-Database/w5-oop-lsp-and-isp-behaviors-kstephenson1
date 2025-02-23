namespace w5_assignment_ksteph.FileIO.Csv;

using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using w5_assignment_ksteph.Config;
using w5_assignment_ksteph.Entities.Characters;

public class CsvFileHandler : ICharacterIO
{
    private const string CSV_FILE_PATH = "Files/Input.csv";
    private const string CSV_EXT = ".csv";

    // Is used to deserialize generic unit types from csv
    public List<TUnit> ReadUnits<TUnit>(string dir)
    {
        using StreamReader reader = new(dir + CSV_EXT);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);

        IEnumerable<TUnit> units = csv.GetRecords<TUnit>();

        return units.ToList();
    }

    // Is used to serialize generic unit types to csv
    public void WriteUnits<TUnit>(List<TUnit> units, string dir)
    {
        // Checks the Config to determine whether or not to add double quotes to the csv writer output.
        CsvConfiguration config;
        if (Config.CSV_CHARACTER_WRITER_QUOTES_ON_EXPORT)
        {
            config = new CsvConfiguration(CultureInfo.InvariantCulture) { ShouldQuote = args => true };
        }
        else
        {
            config = new CsvConfiguration(CultureInfo.InvariantCulture);
        }

        using StreamWriter writer = new(dir + CSV_EXT);
        using CsvWriter csvOut = new(writer, config);

        csvOut.WriteRecords(units);
    }
}
