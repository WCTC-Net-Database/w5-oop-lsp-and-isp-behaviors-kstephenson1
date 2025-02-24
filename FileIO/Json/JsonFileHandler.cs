namespace w5_assignment_ksteph.FileIO.Json;

using System.Collections.Generic;
using System.Text.Json;

public class JsonFileHandler<TUnit> : ICharacterIO
{
    // JsonFileHandler is used to convert bewtween units and json format.  Just like the CsvFileHandler, this class was refactored
    // to implement generic types.

    private const string JSON_EXT = ".json";
    private readonly JsonSerializerOptions _options = new();

    public JsonFileHandler()
    {
        _options.Converters.Add(new JsonInventoryConverter());      // Using a custom converter to convert json string -> Inventory
        _options.Converters.Add(new JsonPositionConverter());       // Using a custom converter to convert json string -> Position
        _options.WriteIndented = true;                              // Writes the json file in indented format.
    }

    public List<TUnit> ReadUnits<TUnit>(string dir)
    {

        using StreamReader reader = new(dir + JSON_EXT);            // reads from the json file and returns a list of characters.
        string json = reader.ReadToEnd();

        return JsonSerializer.Deserialize<List<TUnit>>(json, _options)!;
    }

    public void WriteUnits<TUnit>(List<TUnit> units, string dir)
    {
        using StreamWriter writer = new(dir + JSON_EXT);            // Takes a list of characters and writes to the json file
        writer.WriteLine(JsonSerializer.Serialize<List<TUnit>>(units, _options));
    }
}
