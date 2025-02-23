﻿using Spectre.Console;
using System.Data;
using w5_assignment_ksteph.DataHelper;

namespace w5_assignment_ksteph.UI;

public class InteractiveMainMenu : InteractiveMenu
{
    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.
    public void AddMenuItem(string name, string desc, Action action)
    {
        _menuItems.Add(new InteractiveMainMenuItem(_menuItems.Count, name, desc, action));
    }

    public void Action(int selection)
    {
        // The Action method takes in a selecion from the main menu, then triggers the action associated with that menu item.
        List<InteractiveMainMenuItem> menuItems = new();

        foreach (MenuItem item in _menuItems) // Casts each of the MenuItems into MainMenuItems so the actions can work.
        {
            menuItems.Add((InteractiveMainMenuItem)item);
        }

        menuItems[selection].Action(); // Runs the action selected.
    }

    protected override bool MenuSelectEnter()
    {
        Action(_selectedIndex);
        return (_selectedIndex == _menuItems.Count - 1) ? true : false;
    }
}

