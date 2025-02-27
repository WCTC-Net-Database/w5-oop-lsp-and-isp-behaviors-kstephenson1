using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.ItemCommands;
using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.InventoryBehaviors;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.UI.Menus.InteractiveMenus;

namespace w5_assignment_ksteph.UI;

// The UserInterface class contains elements for the UI including the main menu and the exit message.
public static class UserInterface
{
    public static InteractiveMainMenu MainMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<IEntity> UnitSelectionMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<ICommand> CommandMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<IItem> InventoryMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<ICommand> ItemMenu { get; private set; } = new();
    public static InteractiveSelectionMenu<bool> BoolMenu { get; private set; } = new();
    public static Menu ExitMenu { get; private set; } = new();

    public static void BuildMenus() // Builds main menu and he exit message.
    {
        BuildInteractiveMainMenu();
        BuildUnitSelectMenu();
        BuildExitMenu();
    }

    private static void BuildInteractiveMainMenu() // Builds the main menu.  The main menu stores an index (AutoNumber), option, description, and an action.
                                                   // Used for quick and easy reference later when these menus are shown and the selection action is executed.
    {
        MainMenu = new();
        MainMenu.AddMenuItem("Display All Characters",  "Displays all characters and items in their inventory.",    UnitManager.DisplayCharacters);
        MainMenu.AddMenuItem("Find Character",          "Finds an existing character by name.",                     CharacterUtilities.FindCharacter);
        MainMenu.AddMenuItem("New Character",           "Creates a new character.",                                 CharacterUtilities.NewCharacter);
        MainMenu.AddMenuItem("Level Up Chracter",       "Levels an existing character.",                            CharacterUtilities.LevelUp);
        MainMenu.AddMenuItem("Change File Format",      "Changes the file format between Csv and Json",             FileManager<Character>.SwitchFileType);
        MainMenu.AddMenuItem("Start Game",              "",                                                         DoNothing);
        MainMenu.BuildTable();
    }

    private static void BuildExitMenu() // Builds the exit message.  It's technically a menu but who cares.
    {
        ExitMenu = new();
        ExitMenu.AddMenuItem("                                                                      ");
        ExitMenu.AddMenuItem("           Thank you for using the RPG Character Simulator.           ");
        ExitMenu.AddMenuItem("                              By Kyle S.                              ");
        ExitMenu.AddMenuItem("                                                                      ");
        ExitMenu.BuildTable();
    }

    public static void BuildUnitSelectMenu()
    {
        int prevIndex = UnitSelectionMenu.GetSelectedIndex();
        UnitSelectionMenu = new(prevIndex);

        // Adds all the characters to the unit list using green letters.
        foreach (IEntity unit in UnitManager.Characters.Units)
        {
            // Strikethrough and dim the unit info if the unit is not alive.
            if (unit.HitPoints <= 0)
            {
                UnitSelectionMenu.AddMenuItem($"[green][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                UnitSelectionMenu.AddMenuItem($"[green][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        // Adds all the monsters to the unit list using red letters.
        foreach (IEntity unit in UnitManager.Monsters.Units)
        {
            if (unit.HitPoints <= 0)
            {
                // Strikethrough and dim the unit info if the unit is not alive.
                UnitSelectionMenu.AddMenuItem($"[red][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                UnitSelectionMenu.AddMenuItem($"[red][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        UnitSelectionMenu.AddMenuItem($"Exit Game", $"", null!);

    }
    public static ICommand ShowCommandMenu(IEntity unit, string prompt)
    {
        // Builds the menu that is used to select commands.
        CommandMenu = new();

        CommandMenu.AddMenuItem("Move", "Moves the unit.", new MoveCommand(null!));

        if (unit is IHaveInventory)
        {
            if (unit.Inventory.Items!.Count != 0)
            {
                CommandMenu.AddMenuItem("Items", "Uses an item in this unit's inventory.", new UseItemCommand(null!));
            }
            else
            {
                CommandMenu.AddMenuItem("[dim]Items[/]", "[dim]Uses an item in this unit's inventory.[/]", new UseItemCommand(null!));
            }
        }

        if (unit is IAttack)
        {
            CommandMenu.AddMenuItem("Attack", "Attacks a target unit.", new AttackCommand(null!, null!));
        }

        if (unit is IHeal)
        {
            CommandMenu.AddMenuItem("Heal", "Heals a target unit.", new HealCommand(null!, null!));
        }

        if (unit is IHeal || unit is ICastable)
        {
            CommandMenu.AddMenuItem("Cast", "Casts a spell.", new CastCommand(null!, "null"));
        }

        CommandMenu.AddMenuItem("Go Back", "", null!);
        CommandMenu.BuildTable();
        return CommandMenu.Display(prompt);

    }

    public static void BuildBoolMenu()
    {
        // A menu that asks the user for a yes or no and returns the selection.
        BoolMenu = new();
        BoolMenu.AddMenuItem("Yes", "", true);
        BoolMenu.AddMenuItem("No", "", true);
        BoolMenu.BuildTable();
    }

    public static IItem ShowInventoryMenu(IEntity unit, string prompt)
    {
        InventoryMenu = new();
        foreach (IItem item in unit.Inventory.Items!)
        {
            if (item is IConsumableItem consumableItem)
            {
                InventoryMenu.AddMenuItem($"{consumableItem.Name}", $"[[{consumableItem.UsesLeft}/{consumableItem.MaxUses}]] {consumableItem.Description}", item);
            }
            else if (item is IWeaponItem weaponItem)
            {
                unit.Inventory.IsEquipped(out IItem? equippedItem);
                if (weaponItem == equippedItem)
                {
                    InventoryMenu.AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description} (Equipped)", item);
                }
                else
                {
                    InventoryMenu.AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", item);
                }
            }
            else
            {
                InventoryMenu.AddMenuItem(item.Name, item.Description, item);
            }
        }
        InventoryMenu.AddMenuItem("Go Back", "", null!);
        InventoryMenu.BuildTable();
        return InventoryMenu.Display(prompt);
    }

    public static ICommand ShowItemMenu(IItem item, string prompt)
    {
        ItemMenu = new();

        ItemMenu.AddMenuItem($"Drop Item", $"Get rid of the item forever.", new DropItemCommand(null!, null!));
        ItemMenu.AddMenuItem($"Trade Item", $"Gives this item to someone else.", new TradeItemCommand(null!, null!));

        if (item is IConsumableItem consumableItem)
        {
            ItemMenu.AddMenuItem($"Use Item", $"{consumableItem.Description}", new UseItemCommand(null!));
        }

        if (item is IWeaponItem weaponItem)
        {
            weaponItem.Inventory.IsEquipped(out IItem? equippedItem);
            if (weaponItem == equippedItem)
            {
                ItemMenu.AddMenuItem($"[dim]Equip Item[/]", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", null!);
            }
            else
            {
                ItemMenu.AddMenuItem($"Equip Item", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", new EquipCommand(null!, null!));
            }
        }
        
        ItemMenu.AddMenuItem("Go Back", "", null!);
        ItemMenu.BuildTable();
        return ItemMenu.Display(prompt);
    }

    public static void Exit() // Shows the exit menu.
    {
        Console.Clear();
        ExitMenu.Show();
    }

    private static void DoNothing() { } // This method does nothing...  or does it?
}
