using Spectre.Console;
using System.Data;
using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.UI;

public class InteractiveUnitSelectionMenu : InteractiveMenu
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.
    public void AddMenuItem(string name, string desc, IEntity unit)
    {
        _menuItems.Add(new InteractiveUnitSelectionMenuItem(_menuItems.Count, name, desc, unit));
    }

    public IEntity RunInteractiveMenuReturnUnit(string prompt)
    {
        IEntity unit = null;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            BuildTable();
            Show();
            ConsoleKey key = ReturnValidKey();
            unit = DoKeyActionReturnUnit(key, out exit);
        }
        return unit;
    }

    public IEntity GetUnit(int selection)
    {
        // The Action method takes in a selecion from the main menu, then triggers the action associated with that menu item.
        List<InteractiveUnitSelectionMenuItem> menuItems = new();

        foreach (MenuItem item in _menuItems) // Casts each of the MenuItems into MainMenuItems so the actions can work.
        {
            menuItems.Add((InteractiveUnitSelectionMenuItem)item);
        }

        return menuItems[selection].Unit; // Runs the action selected.
    }

    protected bool MenuSelectEnterReturnUnit(out IEntity unit)
    {
        unit = GetUnit(_selectedIndex);
        return true;
    }
    protected IEntity DoKeyActionReturnUnit(ConsoleKey key, out bool exit)
    {
        IEntity unit = null;
        exit = false;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                MenuSelectUp();
                break;
            case ConsoleKey.DownArrow:
                MenuSelectDown();
                break;
            case ConsoleKey.Enter:
                exit = MenuSelectEnterReturnUnit(out unit);
                break;
        }
        return unit;
    }
}

