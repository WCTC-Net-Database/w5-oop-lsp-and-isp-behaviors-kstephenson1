﻿using System.Diagnostics;
using w4_assignment_ksteph.Characters;
using w4_assignment_ksteph.FileIO;

namespace w4_assignment_ksteph.UI;

// The UserInterface class contains elements for the UI including the main menu and the exit message.
public static class UserInterface
{
    public static MainMenu MainMenu { get; private set; } = new();
    public static Menu ExitMenu { get; private set; } = new();

    public static void BuildMenus() // Builds main menu and he exit message.
    {
        BuildMainMenu();
        BuildExitMenu();
    }

    private static void BuildMainMenu() // Builds the main menu.  The main menu stores an index (AutoNumber), option, description, and an action.
                                        // Used for quick and easy reference later when these menus are shown and the selection action is executed.
    {
        MainMenu = new();
        MainMenu.AddMenuItem("Display All Characters", "Displays all characters and items in their inventory.", CharacterManager.DisplayAllCharacters);
        MainMenu.AddMenuItem("Find Character", "Finds an existing character by name.", CharacterFunctions.FindCharacter);
        MainMenu.AddMenuItem("New Character", "Creates a new character.", CharacterFunctions.NewCharacter);
        MainMenu.AddMenuItem("Level Up Chracter", "Levels an existing character.", CharacterFunctions.LevelUp);
        MainMenu.AddMenuItem("Change File Format", "Changes the file format between Csv and Json", FileManager.SwitchFileType);
        MainMenu.AddMenuItem("Exit", "Ends the program.", DoNothing);
        MainMenu.BuildTable();
    }

    private static void BuildExitMenu() // Builds the exit message.  It's technically a menu but who cares.
    {
        ExitMenu = new();
        ExitMenu.AddMenuItem("Thank you for using the RPG Character Editor.");
        ExitMenu.BuildTable();
    }

    private static void DoNothing() // This method does nothing... or does it?
    {
        throw new UnreachableException("Error: Something did nothing and it shouldn't have");
    }
}
