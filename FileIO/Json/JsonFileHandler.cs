namespace w5_assignment_ksteph.FileIO.Json;

using System.Collections.Generic;
using System.Text.Json;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;

public class JsonFileHandler : ICharacterIO
{
    // JsonFileHandler is used to convert bwtween characters and json format

    private const string JSON_FILE_PATH = "Files/Input.json";
    private const string JSON_EXT = ".json";
    private readonly JsonSerializerOptions _options = new();

    public JsonFileHandler()
    {
        _options.Converters.Add(new JsonInventoryConverter());      // Using a custom converter to convert json string -> Inventory
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
