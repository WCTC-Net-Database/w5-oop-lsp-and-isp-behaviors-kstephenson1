using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities;

public static class UnitManager
{
    public static UnitSet<Character> Characters { get; private set; } = new();
    public static UnitSet<Monster> Monsters { get; private set; } = new();

    public static void DisplayCharacters()                       //Displays each character's information.
    {
        Console.Clear();

        foreach (Character character in Characters.Units)
        {
            character.DisplayCharacterInfo();
        }
    }

    public static void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        Characters.Units = new FileManager<Character>().ImportUnits();
    }

    public static void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        new FileManager<Character>().ExportUnits(Characters.Units);
    }


    public static void AddCharacter(Character character)            // Adds a new character to the stored characters list.
    {
        Characters.AddUnit(character);
    }

    public static void DeleteCharacter(Character character)         // Removes a character from the stored characters list.
    {
        Characters.DeleteUnit(character);
    }
}
