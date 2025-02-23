namespace w5_assignment_ksteph.Entities.Characters;

using w5_assignment_ksteph.FileIO;


// The CharacterHandler class contains methods that manipulate Characters data, including displaying, adding, and leveling up characters.

public static class CharacterCollection
{
    public static List<Character> Characters { get; set; } = new(); // A list of characters objects for reference

    public static void DisplayAllCharacters()                       //Displays each character's information.
    {
        Console.Clear();

        foreach (Character character in Characters)
        {
            character.DisplayCharacterInfo();
        }
    }

    public static void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        Characters = new FileManager<Character>().ImportUnits();
    }

    public static void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        new FileManager<Character>().ExportUnits(Characters);
    }


    public static void AddCharacter(Character character)            // Adds a new character to the stored characters list.
    {
        Characters.Add(character);
    }

    public static void DeleteCharacter(Character character)         // Removes a character from the stored characters list.
    {
        Characters.Remove(character);
    }
}
