﻿using Spectre.Console;

namespace w4_assignment_ksteph.UI;

public class Menu
{
    // The Menu class is an abstract class to build other menus off of.  The Menu class holds a table which is part of the user interface
    // which is displayed to the user.  The Menu also holds menu items, which can store different types of data.
    protected Table _table = new();
    protected List<MenuItem> _menuItems = new();

    public virtual void AddMenuItem(string name) // Adds a new menu item to the menu.
    {
        _menuItems.Add(new MenuItem(_menuItems.Count + 1, name));
    }

    public virtual void BuildTable() // Builds and stores a custom table for the menu using the menu items stored.
    {
        _table.AddColumn("Header");

        foreach (MenuItem item in _menuItems)
        {
            _table.AddRow(item.Name);
        }
        _table.HideHeaders();
    }

    public virtual void Show() // Shows the menu (Shows the table)
    {
        AnsiConsole.Write(_table);
    }

    public virtual void Show(bool clearConsole) // Shows the menu (Shows the table) with an option to clear the console.
    {
        if (clearConsole)
            Console.Clear();

        AnsiConsole.Write(_table);
    }

    public int Count() => _menuItems.Count; //Returns the number of menu items.
}

