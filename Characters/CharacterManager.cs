namespace w4_assignment_ksteph.Characters;

using w4_assignment_ksteph.FileIO;


// The CharacterHandler class contains methods that manipulate Characters data, including displaying, adding, and leveling up characters.

public static class CharacterManager
{
    public static List<Character> Characters { get; set; } = new(); // A list of characters objects for reference

    public static void ImportCharacters()                           //Imports the characters from the csv file and stores them.
    {
        Characters = new FileManager().ImportCharacters();
    }

    public static void ExportCharacters()                           //Exports the stored characters into the specified csv file
    {
        new FileManager().ExportCharacters(Characters);
    }

    public static void DisplayAllCharacters()                       //Displays each character's information.
    {
        Console.Clear();

        foreach (Character character in CharacterManager.Characters)
        {
            character.DisplayCharacterInfo();
        }
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
