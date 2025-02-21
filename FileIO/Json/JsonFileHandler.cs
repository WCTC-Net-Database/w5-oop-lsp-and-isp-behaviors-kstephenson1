namespace w4_assignment_ksteph.FileIO.Json;

using System.Collections.Generic;
using System.Text.Json;
using w4_assignment_ksteph.Characters;

public class JsonFileHandler : ICharacterIO
{
    // JsonFileHandler is used to convert bwtween characters and json format

    private const string JSON_FILE_PATH = "Files/Input.json";
    private readonly JsonSerializerOptions _options = new();

    public JsonFileHandler()
    {
        _options.Converters.Add(new JsonInventoryConverter());      // Using a custom converter to convert json string -> Inventory
        _options.WriteIndented = true;                              // Writes the json file in indented format.
    }

    public List<Character> ReadCharacters()
    {

        using StreamReader reader = new(JSON_FILE_PATH);            // reads from the json file and returns a list of characters.
        string json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<List<Character>>(json, _options)!;
    }

    public void WriteCharacters(List<Character> characters)
    {
        using StreamWriter writer = new(JSON_FILE_PATH);            // Takes a list of characters and writes to the json file
        writer.WriteLine(JsonSerializer.Serialize<List<Character>>(characters, _options));
    }
}
