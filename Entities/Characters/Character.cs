﻿namespace w5_assignment_ksteph.Entities.Characters;

using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.FileIO.Csv;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.UI;

// The character class stores information for each character.  It is used in conjunction with CsvHelper to import and export character information to csv format.
public class Character : Unit
{

    [JsonConstructor]
    public Character() { }

    public Character(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
    }

    public void DisplayCharacterInfo() => CharacterUI.DisplayCharacterInfo(this); // Displays the character info.

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{HitPoints},{Inventory}";
    }

    public override void Move(Position position)
    {
        Console.WriteLine($"{Name} moved to {position.ToString}");
    }
}
