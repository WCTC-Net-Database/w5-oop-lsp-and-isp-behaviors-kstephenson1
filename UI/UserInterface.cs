using System.Diagnostics;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.UI;

// The UserInterface class contains elements for the UI including the main menu and the exit message.
public static class UserInterface
{
    public static InteractiveMainMenu MainMenu { get; private set; } = new();
    public static InteractiveUnitSelectionMenu UnitSelectionMenu { get; private set; } = new();
    public static Menu ExitMenu { get; private set; } = new();

    public static void BuildMenus() // Builds main menu and he exit message.
    {
        BuildInteractiveMainMenu();
        BuildUnitSelectMenu();
        BuildExitMenu();
    }

    public static void UpdateUnitSelectMenu()
    {
        UnitSelectionMenu = new();
        foreach (IEntity unit in UnitManager.Characters.Units)
        {
            UnitSelectionMenu.AddMenuItem(unit.Name, $"Level {unit.Level} {unit.Class}", unit);
        }
        foreach (IEntity unit in UnitManager.Monsters.Units)
        {
            UnitSelectionMenu.AddMenuItem(unit.Name, $"Level {unit.Level} {unit.Class}", unit);
        }
    }
    private static void BuildInteractiveMainMenu() // Builds the main menu.  The main menu stores an index (AutoNumber), option, description, and an action.
                                                   // Used for quick and easy reference later when these menus are shown and the selection action is executed.
    {
        MainMenu = new();
        MainMenu.AddMenuItem("Display All Characters", "Displays all characters and items in their inventory.", UnitManager.DisplayCharacters);
        MainMenu.AddMenuItem("Find Character", "Finds an existing character by name.", CharacterUtilities.FindCharacter);
        MainMenu.AddMenuItem("New Character", "Creates a new character.", CharacterUtilities.NewCharacter);
        MainMenu.AddMenuItem("Level Up Chracter", "Levels an existing character.", CharacterUtilities.LevelUp);
        MainMenu.AddMenuItem("Change File Format", "Changes the file format between Csv and Json", FileManager<Character>.SwitchFileType);
        MainMenu.AddMenuItem("Start Game", "Starts the game", DoNothing);
        MainMenu.BuildTable();
    }

    private static void BuildExitMenu() // Builds the exit message.  It's technically a menu but who cares.
    {
        ExitMenu = new();
        ExitMenu.AddMenuItem("Thank you for using the RPG Character Editor.");
        ExitMenu.BuildTable();
    }

    public static void BuildUnitSelectMenu() => UpdateUnitSelectMenu();

    public static void Exit() // Shows the exit menu.
    {
        Console.Clear();
        ExitMenu.Show();
    }

    private static void DoNothing() { } // This method does nothing...  or does it?
}
