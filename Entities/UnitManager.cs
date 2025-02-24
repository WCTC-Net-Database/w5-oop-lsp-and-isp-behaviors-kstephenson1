using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;
using w5_assignment_ksteph.FileIO;

namespace w5_assignment_ksteph.Entities;

public static class UnitManager
{
    // The UnitManager class is a static class that holds lists of units for reference.
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
        Characters.Units = new FileManager<Character>().ImportUnits<Character>();

        List<Monster> importedMonsters = new FileManager<Monster>().ImportUnits<Monster>();
        foreach (Monster monster in importedMonsters)
        {
            if (monster.Class == "Archer")
                Monsters.AddUnit(new Archer() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory });
            if (monster.Class == "Ghost")
                Monsters.AddUnit(new Ghost() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory });
            if (monster.Class == "Goblin")
                Monsters.AddUnit(new Goblin() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory });
            if (monster.Class == "Mage")
                Monsters.AddUnit(new Mage() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory });
        }
    }

    public static void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        new FileManager<Character>().ExportUnits<Character>(Characters.Units);
        new FileManager<Monster>().ExportUnits<Monster>(Monsters.Units);
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
