﻿using w4_assignment_ksteph.FileIO;
using w4_assignment_ksteph.Inventories;

namespace w4_assignment_ksteph.UI;

public static class InventoryUI
{
    // The inventoryUI class contains methods to show the inventory UI.  Will probably be rededigned later.

    [Obsolete]
    public static void DisplayInventory(Inventory inventory) // takes in an inventory and displays it to the user
    {
        DisplayInventory(InventorySerializer.Serialize(inventory)!);
    }

    [Obsolete]
    private static void DisplayInventory(string inventoryString) // Takes the inventory string, splits it, and displays the inventory to the user.
    {
        Console.WriteLine($"Inventory:");

        if (inventoryString == "" || inventoryString == null)
        {
            Console.WriteLine("    - (Empty)");
        }
        else
        {
            List<Item> items = InventorySerializer.Deserialize(inventoryString).Items!;

            foreach (Item item in items)
            {
                Console.WriteLine($"    - {item.Name}");
            }

            Console.WriteLine("\n");
        }
    }
}
