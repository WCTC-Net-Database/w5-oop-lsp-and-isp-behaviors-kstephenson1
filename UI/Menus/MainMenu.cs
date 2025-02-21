using Spectre.Console;

namespace w5_assignment_ksteph.UI;

public class MainMenu : Menu
{
    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.
    public void AddMenuItem(string name, string desc, Action action)
    {
        _menuItems.Add(new MainMenuItem(_menuItems.Count + 1, name, desc, action));
    }

    public override void BuildTable()
    {
        // Creates a table using Spectre.Console and stores that table for later.
        _table.AddColumn("#");
        _table.AddColumn("Selection");
        _table.AddColumn("Description");

        foreach (MainMenuItem item in _menuItems)
        {
            _table.AddRow(item.Index.ToString(), item.Name, item.Description);
        }
        _table.HideHeaders();
    }

    public void Action(int selection)
    {
        // The Action method takes in a selecion from the main menu, then triggers the action associated with that menu item.
        List<MainMenuItem> menuItems = new();

        foreach (MenuItem item in _menuItems) // Casts each of the MenuItems into MainMenuItems so the actions can work.
        {
            menuItems.Add((MainMenuItem)item); 
        }

        menuItems[selection - 1].Action(); // Runs the action selected.
    }
}

