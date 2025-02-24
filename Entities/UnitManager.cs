using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.UI;

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
        List<Character> importedCharacters = new FileManager<Character>().ImportUnits<Character>();

        foreach (Character character in importedCharacters)
        {
            // Units imported from the characters file are imported as characters.  This block of text converts these characters to their respective types.
            // Is there a way to automate this without having to add a new line for every unit I add?
            if (character.Class == "Cleric")
                Characters.AddUnit(new Cleric() { Name = character.Name, Class = character.Class, Level = character.Level, HitPoints = character.HitPoints, Inventory = character.Inventory, Position = character.Position });
            if (character.Class == "Fighter")
                Characters.AddUnit(new Fighter() { Name = character.Name, Class = character.Class, Level = character.Level, HitPoints = character.HitPoints, Inventory = character.Inventory, Position = character.Position });
            if (character.Class == "Knight")
                Characters.AddUnit(new Knight() { Name = character.Name, Class = character.Class, Level = character.Level, HitPoints = character.HitPoints, Inventory = character.Inventory, Position = character.Position });
            if (character.Class == "Rogue")
                Characters.AddUnit(new Rogue() { Name = character.Name, Class = character.Class, Level = character.Level, HitPoints = character.HitPoints, Inventory = character.Inventory, Position = character.Position });
            if (character.Class == "Wizard")
                Characters.AddUnit(new Wizard() { Name = character.Name, Class = character.Class, Level = character.Level, HitPoints = character.HitPoints, Inventory = character.Inventory, Position = character.Position });
        }

        List<Monster> importedMonsters = new FileManager<Monster>().ImportUnits<Monster>();
        foreach (Monster monster in importedMonsters)
        {
            // Units imported from the monsters file are imported as monsters.  This block of text converts these monsters to their respective types.
            // Is there a way to automate this without having to add a new line for every unit I add?
            if (monster.Class == "Archer")
                Monsters.AddUnit(new EnemyArcher() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory, Position = monster.Position });
            if (monster.Class == "Ghost")
                Monsters.AddUnit(new EnemyGhost() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory, Position = monster.Position });
            if (monster.Class == "Goblin")
                Monsters.AddUnit(new EnemyGoblin() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory, Position = monster.Position });
            if (monster.Class == "Mage")
                Monsters.AddUnit(new EnemyMage() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory, Position = monster.Position });
            if (monster.Class == "Cleric")
                Monsters.AddUnit(new EnemyCleric() { Name = monster.Name, Class = monster.Class, Level = monster.Level, HitPoints = monster.HitPoints, Inventory = monster.Inventory, Position = monster.Position });
        }

        foreach (IEntity unit in Characters.Units)
        {
            unit.MaxHitPoints = unit.HitPoints;
        }

        foreach (IEntity unit in Monsters.Units)
        {
            unit.MaxHitPoints = unit.HitPoints;
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
