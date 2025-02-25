using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.Behaviors.ItemBehaviors;
using w5_assignment_ksteph.UI;

namespace w5_assignment_ksteph.Inventories;

public static class ItemManager
{
    // The ItemManager class is a static class that holds lists of items for reference.
    public static List<Item> Items { get; private set; } = new();

    public static void DisplayItems()                           //Displays each item's information.
    {
        Console.Clear();

        DisplayItemInfo(Items);
    }

    public static void DisplayItemInfo(List<Item> items)
    {

    }

    public static void ImportItems()                           //Imports the items from the files and stores them.
    {
        List<Item> importedItems = new FileManager<Item>().ImportUnits<Item>();

        foreach (Item item in importedItems)
        {
            if (item is IWeaponItem)
            {
                throw new NotImplementedException();
            }
        }
    }

    public static void ExportItems(List<Item> items)                           //Exports the stored items into the specified file
    {
        new FileManager<Item>().ExportItems(items);
    }

    public static void AddItem(Item item)                       // Adds a new item to the stored item list.
    {
        Items.Add(item);
    }

    public static void DeleteItem(Item item)                    // Removes a item from the stored item list.
    {
        Items.Remove(item);
    }
}
