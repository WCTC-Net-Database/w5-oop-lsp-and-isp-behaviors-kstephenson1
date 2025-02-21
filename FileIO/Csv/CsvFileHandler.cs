namespace w5_assignment_ksteph.FileIO.Csv;

using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using w5_assignment_ksteph.Characters;
using w5_assignment_ksteph.Config;

public class CsvFileHandler : ICharacterIO
{
    private const string CSV_FILE_PATH = "Files/Input.csv";

    // CsvFileHandler is used to convert bwtween characters and csv
    public List<Character> ReadCharacters()
    {
        using StreamReader reader = new(CSV_FILE_PATH);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);

        IEnumerable<Character> characters = csv.GetRecords<Character>();

        return characters.ToList();
    }

    // CsvCharacterWriter is used to export the characters to a text file.
    public void WriteCharacters(List<Character> characters)
    {
        List<Character> outputCharacters = new();

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

        using StreamWriter writer = new(CSV_FILE_PATH);
        using CsvWriter csvOut = new(writer, config);

        csvOut.WriteRecords(characters);
    }
}
