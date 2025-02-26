namespace w5_assignment_ksteph.Entities.Characters;

using System.Text.Json.Serialization;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.UI;

// The character class stores information for each character.
public class Character : Unit
{
    [JsonConstructor]
    public Character() { }

    public Character(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
    }

    public void DisplayCharacterInfo() => CharacterUI.DisplayCharacterInfo(this); // Displays the character info.

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{HitPoints},{Inventory}";
    }
}
