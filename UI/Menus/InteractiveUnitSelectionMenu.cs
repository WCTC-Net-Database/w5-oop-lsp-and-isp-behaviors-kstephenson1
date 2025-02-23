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

    protected override bool MenuSelectEnter()
    {
        IEntity selectedUnit = GetUnit(_selectedIndex);
        return (_selectedIndex == _menuItems.Count - 1) ? true : false;
    }
}

