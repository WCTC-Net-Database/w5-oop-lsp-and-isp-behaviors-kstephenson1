using System.Diagnostics;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.FileIO;

namespace w5_assignment_ksteph.UI;

// The UserInterface class contains elements for the UI including the main menu and the exit message.
public static class UserInterface
{
    public static InteractiveMainMenu InteractiveMainMenu { get; private set; } = new();
    public static Menu ExitMenu { get; private set; } = new();

    public static void BuildMenus() // Builds main menu and he exit message.
    {
        BuildInteractiveMainMenu();
        BuildExitMenu();
    }

    private static void BuildInteractiveMainMenu() // Builds the main menu.  The main menu stores an index (AutoNumber), option, description, and an action.
                                        // Used for quick and easy reference later when these menus are shown and the selection action is executed.
    {
        InteractiveMainMenu = new();
        InteractiveMainMenu.AddMenuItem("Display All Characters", "Displays all characters and items in their inventory.", CharacterManager.DisplayAllCharacters);
        InteractiveMainMenu.AddMenuItem("Find Character", "Finds an existing character by name.", CharacterFunctions.FindCharacter);
        InteractiveMainMenu.AddMenuItem("New Character", "Creates a new character.", CharacterFunctions.NewCharacter);
        InteractiveMainMenu.AddMenuItem("Level Up Chracter", "Levels an existing character.", CharacterFunctions.LevelUp);
        InteractiveMainMenu.AddMenuItem("Change File Format", "Changes the file format between Csv and Json", FileManager.SwitchFileType);
        InteractiveMainMenu.AddMenuItem("Exit", "Ends the program.", Exit);
        InteractiveMainMenu.BuildTable();
    }

    private static void BuildExitMenu() // Builds the exit message.  It's technically a menu but who cares.
    {
        ExitMenu = new();
        ExitMenu.AddMenuItem("Thank you for using the RPG Character Editor.");
        ExitMenu.BuildTable();
    }

    private static void Exit() // Shows the exit menu.
    {
        Console.Clear();
        ExitMenu.Show();
    }
}
