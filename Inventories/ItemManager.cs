using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Items;

namespace w5_assignment_ksteph.Inventories;

public static class ItemManager
{
    // The ItemManager class is a static class that holds lists of items for reference.
    public static List<Item> Items { get; private set; } = new();

    public static void DisplayItems()                                           //Displays each item's information.
    {
        Console.Clear();

        foreach (Item item in Items)
        {
            Console.WriteLine(item.Name);
        }
    }

    public static void Import<TItem>() where TItem : Item                       //Imports the items from the files and stores them.
    {
        List<TItem> importedItems = new FileManager<TItem>().Import<TItem>();

        Items.AddRange(importedItems);
    }

    public static void Export<TItem>(List<TItem> items)                         //Exports the stored items into the specified file
    {
        new FileManager<TItem>().Export<TItem>(items);
    }

    public static void AddItem(Item item)                                       // Adds a new item to the stored item list.
    {
        Items.Add(item);
    }

    public static void DeleteItem(Item item)                                    // Removes a item from the stored item list.
    {
        Items.Remove(item);
    }
}
