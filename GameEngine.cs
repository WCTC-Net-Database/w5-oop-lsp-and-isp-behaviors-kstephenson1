using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.UI;

namespace w5_assignment_ksteph;

public class GameEngine
{
    public void StartGameEngine()
    {
        Initialization();
        Run();
        End();
    }

    public static void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        UnitManager.ImportUnits(); //Imports the caracters from the csv or json file.
        UserInterface.BuildMenus(); // Builds the menus and prepares the user interface tables.
    }

    public static void Run()
    {
        //UserInterface.MainMenu.RunInteractiveMenu();
        //UserInterface.UnitSelectionMenu.RunInteractiveMenu();

        UserInterface.UpdateUnitSelectMenu();
        //IEntity testunit = UserInterface.UnitSelectionMenu.RunInteractiveMenuReturnUnit();
       // Console.WriteLine(testunit);

        List<IEntity> entities = new();
        foreach(IEntity entity in UnitManager.Characters.Units)
        {
            entities.Add(entity);
        }

        foreach(IEntity entity in UnitManager.Monsters.Units)
        {
            entities.Add(entity);
            Console.WriteLine(entity.ToString());
        }

        UnitManager.Monsters.ExportUnits();

        while (true)
        {
            Console.WriteLine("Select attacking unit");
            IEntity unit1 = UserInterface.UnitSelectionMenu.RunInteractiveMenuReturnUnit("Select first unit");

            Console.WriteLine("Select target unit");
            IEntity unit2 = UserInterface.UnitSelectionMenu.RunInteractiveMenuReturnUnit("Select second unit");

            if (unit1 != unit2)
            {
                // Encounter where damage is 1-4, hit chance is 70%, and crit chance is 10%
                EncounterStats encounter = new(unit1, unit2, 1, 4, 70, 10);

                AttackCommand attack = new(encounter);
                //MoveCommand move = new(entities[3], entities[3].Position + new Position(1, 1));
                //FlyCommand fly = new(entities[5], entities[3].Position + new Position(1, 1));
                //ShootCommand shoot = new(encounter2);
                //CastCommand cast = new(entities[8], "fireball");

                InvokeCommand invoker = new InvokeCommand();
                Console.WriteLine("");
                invoker.ExecuteCommand(attack);
                //invoker.ExecuteCommand(move);
                //invoker.ExecuteCommand(fly);
                //invoker.ExecuteCommand(shoot);
                //invoker.ExecuteCommand(cast);


            }
            else
            {
                Console.WriteLine($"{unit1.Name} should not attack themselves.  That's not very nice!");
            }

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
