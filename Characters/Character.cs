namespace w4_assignment_ksteph.Characters;

using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w4_assignment_ksteph.FileIO.Csv;
using w4_assignment_ksteph.Inventories;
using w4_assignment_ksteph.UI;

// The character class stores information for each character.  It is used in conjunction with CsvHelper to import and export character information to csv format.
public class Character
{
    [Name("Name")]                  // CsvHelper Attribute
    public required string Name { get; set; }

    [Name("Class")]                 // CsvHelper Attribute
    public required string Class { get; set; }

    [Name("Level")]                 // CsvHelper Attribute
    public required int Level { get; set; }

    [Name("HP")]                    // CsvHelper Attribute
    [JsonPropertyName("HP")]        // Json Atribute
    public required int HitPoints { get; set; }

    [Name("Equipment")]             // CsvHelper Attribute
    [JsonPropertyName("Equipment")] // Json Atribute
    [TypeConverter(typeof(CsvInventoryConverter))] // CsvHelper Attribute that helps CsvHelper import a new inventory object instead of a string.
    public required Inventory Inventory { get; set; }

    public Character() { }

    public Character(string name, string characterclass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterclass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
    }

    public void DisplayCharacterInfo() => CharacterUI.DisplayCharacterInfo(this); // Displays the character info.

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{HitPoints},{Inventory}";
    }
}
