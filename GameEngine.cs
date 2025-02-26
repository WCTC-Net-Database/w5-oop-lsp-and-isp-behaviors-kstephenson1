using Spectre.Console;
using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.Items.WeaponItems;
using w5_assignment_ksteph.UI;

namespace w5_assignment_ksteph;

public class GameEngine
{
    public void StartGameEngine()
    {        
        Initialization();
        Run();
        //Test();
        End();
    }

    void Test()
    {
        //ItemManager.Import<WeaponItem>();
        //ItemManager.DisplayItems();

        IEntity test = UnitManager.Characters.Units[0];
        Console.WriteLine("Character | " + test.ToString());
        Console.WriteLine("Character.Inventory.Item | " + test.Inventory.Items[0].ToString());
        Console.WriteLine("Character.Inventory.Item.Inventory | " + test.Inventory.Items[0].Inventory);
        Console.WriteLine("Character.Inventory.Item.Inventory.Character | " + test.Inventory.Items[0].Inventory.Unit);

        //Fighter test2 = new("Test", "Fighter", 20, 20, new(), new(0, 0));
        //test2.Inventory.AddItem(new("testitem"));
        //Console.WriteLine("Character.Inventory.Item.Inventory.Character | " + test2.Inventory.Items[0].Inventory.Unit);

        //UnitManager.Characters.AddUnit(test2);
    }

    public static void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        UnitManager.ImportUnits(); //Imports the caracters from the csv or json file.
        UserInterface.BuildMenus(); // Builds the menus and prepares the user interface tables.
    }

    public static void Run()
    {
        // Shows the main menu.  Allows you to add/edit characters before the game is started.
        UserInterface.MainMenu.RunInteractiveMenu();

        // Builds the unit select menu.
        UserInterface.BuildUnitSelectMenu();

        List<IEntity> entities = new();

        while (true)
        {
            // Asks the user to choose a unit.
            IEntity unit1 = UserInterface.UnitSelectionMenu.Display("Select unit to control");

            if (unit1.HitPoints <= 0) continue;

            // Asks the user to choose an action for unit.
            ICommand command = UserInterface.CommandMenu.Display($"Select action for {unit1.Name}");

            // If the unit is able to move, the unit moves.
            if (command.GetType() == typeof(MoveCommand))
            {
                if (unit1 is IEntity)
                {
                    int x = Input.GetInt("Enter location's x-coordinate: ");
                    int z = Input.GetInt("Enter location's z-coordinate: ");
                    Position position = new(x, z);
                    unit1.Move(position);
                } else
                {
                    Console.WriteLine($"{unit1.Name} is unable to move!");
                }

            }
            // If the unit has a usable item, it can use an item.
            else if (command.GetType() == typeof(UseItemCommand))
            {
                List<IConsumableItem> usableItems = unit1.Inventory.GetConsumableItems();

                if (usableItems.Count > 0)
                {
                    Item item = UserInterface.ShowInventoryMenu(unit1, $"Select item for {unit1.Name}.");

                    //

                }
                else
                {
                    Console.WriteLine($"{unit1.Name} has no usable items!");
                }

            }// If the unit is able to attack, it attacks.
            else if (command.GetType() == typeof(AttackCommand))
            {
                if (unit1 is IAttack)
                {
                    IEntity unit2 = UserInterface.UnitSelectionMenu.Display($"Select unit being attacked by {unit1.Name}");

                    if (unit1 != unit2)
                    {
                        unit1.Attack(unit2);
                    }
                    else
                    {
                        Console.WriteLine($"{unit1.Name} should not attack themselves.  That's not very nice!");
                    }
                }
                else
                {
                    Console.WriteLine($"{unit1.Name} cannot attack!");
                }

            }
            // If the unit is able to heal, it heals.
            else if (command.GetType() == typeof(HealCommand))
            {
                if (unit1 is IHeal)
                {
                    IEntity unit2 = UserInterface.UnitSelectionMenu.Display($"Select unit being healed by {unit1.Name}");

                    ((IHeal)unit1).Heal(unit2);
                }
                else
                {
                    Console.WriteLine($"{unit1.Name} cannot heal!");
                }

            }
            // If the unit is able to cast spells, it casts a spell.
            else if (command.GetType() == typeof(CastCommand))
            {
                if (unit1 is ICastable)
                {
                    string spell = Input.GetString($"Enter name of spell being cast by {unit1.Name}: ");
                    ((ICastable)unit1).Cast(spell);
                }
                else
                {
                    Console.WriteLine($"{unit1.Name} is not a spellcaster!");
                }
            }

            UserInterface.BuildUnitSelectMenu(); ;

            // Waits for user input.  Escape leaves the program and any other button loops the process.
            Console.WriteLine("\nPress escape to exit or any other key to continue...");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
                return;
        }
    }

    public static void End()
    {
        // Exports the character list back to the chosen file format and ends the program.
        UnitManager.ExportUnits();
    }
}
