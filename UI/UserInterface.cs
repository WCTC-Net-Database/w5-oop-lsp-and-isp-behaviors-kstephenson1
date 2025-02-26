using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.UI.Menus.InteractiveMenus;

namespace w5_assignment_ksteph.UI;

// The UserInterface class contains elements for the UI including the main menu and the exit message.
public static class UserInterface
{
    public static InteractiveMainMenu MainMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<IEntity> UnitSelectionMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<ICommand> CommandMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<Item> InventoryMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<bool> BoolMenu { get; private set; } = new();
    public static Menu ExitMenu { get; private set; } = new();

    public static void BuildMenus() // Builds main menu and he exit message.
    {
        BuildCommandMenu();
        BuildInteractiveMainMenu();
        BuildUnitSelectMenu();
        BuildExitMenu();
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

    public static void BuildUnitSelectMenu()
    {
        int prevIndex = UnitSelectionMenu.GetSelectedIndex();
        UnitSelectionMenu = new(prevIndex);
        foreach (IEntity unit in UnitManager.Characters.Units)
        {
            if (unit.HitPoints <= 0)
            {
                UnitSelectionMenu.AddMenuItem($"[green][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                UnitSelectionMenu.AddMenuItem($"[green][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);

            }
        }
        foreach (IEntity unit in UnitManager.Monsters.Units)
        {
            if (unit.HitPoints <= 0)
            {
                UnitSelectionMenu.AddMenuItem($"[red][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                UnitSelectionMenu.AddMenuItem($"[red][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);

            }
        }
    }
    public static void BuildCommandMenu()
    {
        CommandMenu = new();
        CommandMenu.AddMenuItem("Move", "Moves the unit.", new MoveCommand(null, new()));
        CommandMenu.AddMenuItem("Use Item", "Uses an item in this unit's inventory.", new UseItemCommand(null, null));
        CommandMenu.AddMenuItem("Attack", "Attacks a target unit.", new AttackCommand(null, null));
        CommandMenu.AddMenuItem("Heal", "Heals a target unit.", new HealCommand(null, null));
        CommandMenu.AddMenuItem("Cast", "Casts a spell.", new CastCommand(null, "null"));
        CommandMenu.BuildTable();
    }

    public static void BuildBoolMenu()
    {
        BoolMenu = new();
        BoolMenu.AddMenuItem("Yes", "", true);
        BoolMenu.AddMenuItem("No", "", true);
        BoolMenu.BuildTable();
    }

    public static Item ShowInventoryMenu(IEntity unit, string prompt)
    {
        InventoryMenu = new();
        foreach (Item item in unit.Inventory.Items)
        {
            InventoryMenu.AddMenuItem(item.Name, item.Description, item);
        }
        InventoryMenu.BuildTable();
        return InventoryMenu.Display(prompt);
    }

    public static void Exit() // Shows the exit menu.
    {
        Console.Clear();
        ExitMenu.Show();
    }

    private static void DoNothing() { } // This method does nothing...  or does it?
}
