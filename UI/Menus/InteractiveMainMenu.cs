using Spectre.Console;
using System.Data;
using w5_assignment_ksteph.DataHelper;

namespace w5_assignment_ksteph.UI;

public class InteractiveMainMenu : Menu
{
    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.
    private int _selectedIndex = 0;
    public void AddMenuItem(string name, string desc, Action action)
    {
        _menuItems.Add(new InteractiveMainMenuItem(_menuItems.Count, name, desc, action));
    }

    public void RunInteractiveMenu()
    {
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            BuildTable();
            Show();
            ConsoleKey key = ReturnValidKey();
            DoKeyAction(key, out exit);
        }
    }

    public override void BuildTable()
    {
        _table = new();
        // Creates a table using Spectre.Console and stores that table for later.
        _table.AddColumn("#");
        _table.AddColumn("Selection");
        _table.AddColumn("Description");

        foreach (InteractiveMainMenuItem item in _menuItems)
        {
            _table.AddRow(GetSelectableArrow(item), item.Name, item.Description);
        }
        _table.HideHeaders();
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

    private string GetSelectableArrow(InteractiveMainMenuItem item)
    {
        if (_selectedIndex == item.Index)
        {
            return "->";
        }
        return " ";
    }

    private void MenuSelectUp()
    {
        if (_selectedIndex > 0) _selectedIndex--;
    }

    private void MenuSelectDown()
    {
        if (_selectedIndex < _menuItems.Count - 1)_selectedIndex++;
    }

    private bool MenuSelectEnter()
    {
        Action(_selectedIndex);
        return (_selectedIndex == _menuItems.Count - 1) ? true : false;

    }

    private ConsoleKey ReturnValidKey()
    {
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W or ConsoleKey.UpArrow:
                    return ConsoleKey.UpArrow;
                case ConsoleKey.S or ConsoleKey.DownArrow:
                    return ConsoleKey.DownArrow;
                case ConsoleKey.E or ConsoleKey.Enter:
                    return ConsoleKey.Enter;
                default:
                    break;
            }
        }
    }

    private void WaitForEnterPress()
    {
        AnsiConsole.MarkupLine($"Press [green][[ENTER]][/] to continue...");
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
                return;
        }
    }

    private void DoKeyAction(ConsoleKey key, out bool exit)
    {
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
                exit = MenuSelectEnter();
                WaitForEnterPress();
                break;
        }
    }
}

