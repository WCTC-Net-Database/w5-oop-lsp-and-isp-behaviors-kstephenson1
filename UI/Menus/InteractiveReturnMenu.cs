﻿namespace w5_assignment_ksteph.UI;

public class InteractiveReturnMenu<Ttype> : InteractiveMenu
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.
    public void AddMenuItem(string name, string desc, Ttype selection)
    {
        _menuItems.Add(new InteractiveReturnMenuItem<Ttype>(_menuItems.Count, name, desc, selection));
    }

    public Ttype RunInteractiveMenuReturnUnit(string prompt)
    {
        Ttype selection = default(Ttype)!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            BuildTable();
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public Ttype GetSelection(int selection)
    {
        // The Action method takes in a selecion from the main menu, then triggers the action associated with that menu item.
        List<InteractiveReturnMenuItem<Ttype>> menuItems = new();

        foreach (MenuItem item in _menuItems) // Casts each of the MenuItems into MainMenuItems so the actions can work.
        {
            menuItems.Add((InteractiveReturnMenuItem<Ttype>)item);
        }

        return menuItems[selection].Selection; // Runs the action selected.
    }

    protected bool MenuSelectEnterReturnUnit(out Ttype selection)
    {
        selection = GetSelection(_selectedIndex);
        return true;
    }
    protected Ttype DoKeyActionReturnUnit(ConsoleKey key, out bool exit)
    {
        Ttype selection = default(Ttype)!;
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
                exit = MenuSelectEnterReturnUnit(out selection);
                break;
        }
        return selection;
    }
}

