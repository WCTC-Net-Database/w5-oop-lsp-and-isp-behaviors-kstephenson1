﻿using Spectre.Console;
using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.ItemCommands;
using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.Items.ConsumableItems;
using w5_assignment_ksteph.Items.WeaponItems;
using w5_assignment_ksteph.UI;

namespace w5_assignment_ksteph;

public class GameEngine
{
    public void StartGameEngine()
    {        
        Initialization();
        Run();
        Test();
        End();
    }

    void Test()
    {
       

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

        while (true)
        {
            // Asks the user to choose a unit.
            IEntity unit1 = UserInterface.UnitSelectionMenu.Display("Select unit to control");
            if (unit1 == null) break;

            // If the selected unit is down, restarts
            if (unit1.HitPoints <= 0) continue;

            // Asks the user to choose an action for unit.
            ICommand command = UserInterface.ShowCommandMenu(unit1, $"Select action for {unit1.Name}");
            if (command == null) continue; // Go back was selected, sends back to unit selection.

            // If the unit is able to move, the unit moves.
            if (command.GetType() == typeof(MoveCommand))
            {
                unit1.Move();
            }

            // If the unit has a usable item, it can use an item.
            else if (command.GetType() == typeof(UseItemCommand))
            {
                if (unit1.Inventory.Items!.Count > 0)
                {
                    IItem item = UserInterface.ShowInventoryMenu(unit1, $"Select item for {unit1.Name}.");

                    if ( item != null)
                    {
                        ICommand itemCommand = UserInterface.ShowItemMenu(item, $"Select action for {unit1.Name} to use on {item.Name}");
                        
                        if ( itemCommand != null )
                        {
                            switch (itemCommand)
                            {
                                case EquipCommand:
                                    unit1.Equip((item as WeaponItem)!);
                                    break;
                                case UseItemCommand:
                                    unit1.UseItem(item);
                                    break;
                                case TradeItemCommand:
                                    unit1.TradeItem(item);
                                    break;
                                case DropItemCommand:
                                    unit1.DropItem(item);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
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
                    unit1.Attack(unit2);
                }
            }
            // If the unit is able to heal, it heals.
            else if (command.GetType() == typeof(HealCommand))
            {
                IEntity unit2 = UserInterface.UnitSelectionMenu.Display($"Select unit being healed by {unit1.Name}");
                ((IHeal)unit1).Heal(unit2);
            }
            // If the unit is able to cast spells, it casts a spell.
            else if (command.GetType() == typeof(CastCommand))
            {
                string spell = Input.GetString($"Enter name of spell being cast by {unit1.Name}: ");
                ((ICastable)unit1).Cast(spell);
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
        UserInterface.ExitMenu.Show();
    }
}
