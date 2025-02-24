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
        UserInterface.MainMenu.RunInteractiveMenu();
        UserInterface.UnitSelectionMenu.RunInteractiveMenu();

        UnitManager.Monsters.AddUnit(new Ghost() { Name = "Ghost", Class = "Ghost", Level = 1, HitPoints = 5, MaxHitPoints = 5, Inventory = new(), Position = new(0, 0) });
        UnitManager.Monsters.AddUnit(new Goblin() { Name = "Goblin", Class = "Goblin", Level = 1, HitPoints = 5, MaxHitPoints = 5, Inventory = new(), Position = new(0, 0) });
        UnitManager.Monsters.AddUnit(new Archer() { Name = "Archer", Class = "Archer", Level = 1, HitPoints = 5, MaxHitPoints = 5, Inventory = new(), Position = new(0, 0) });
        UnitManager.Monsters.AddUnit(new Mage() { Name = "Mage", Class = "Mage", Level = 1, HitPoints = 5, MaxHitPoints = 5, Inventory = new(), Position = new(0, 0) });

        List<IEntity> entities = new();
        foreach(IEntity entity in UnitManager.Characters.Units)
        {
            entities.Add(entity);
        }

        foreach(IEntity entity in UnitManager.Monsters.Units)
        {
            entities.Add(entity);
        }

        UnitManager.ExportUnits();

        while (true)
        {
            // Encounter where damage is 1-4, hit chance is 70%, and crit chance is 10%
            EncounterStats encounter = new(entities[5], entities[3], 1, 4, 70, 10);
            EncounterStats encounter2 = new(entities[7], entities[3], 1, 4, 70, 10);

            AttackCommand attack = new(encounter);
            MoveCommand move = new(entities[3], entities[3].Position + new Position(1, 1));
            FlyCommand fly = new(entities[5], entities[3].Position + new Position(1, 1));
            ShootCommand shoot = new(encounter2);
            CastCommand cast = new(entities[8], "fireball");

            InvokeCommand invoker = new InvokeCommand();
            Console.WriteLine("");
            invoker.ExecuteCommand(attack);
            invoker.ExecuteCommand(move);
            invoker.ExecuteCommand(fly);
            invoker.ExecuteCommand(shoot);
            invoker.ExecuteCommand(cast);

            ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                    return;
        }
    }

    public static void End()
    {
        // Exports the character list back to the chosen file format and ends the program.
        UnitManager.ExportUnits();
    }
}
