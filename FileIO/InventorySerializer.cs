namespace w5_assignment_ksteph.FileIO;

using System;
using System.Collections.Generic;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.DataHelper;

public class InventorySerializer
{
    // InventorySerializer contains fuctions to turn a string into List<Item> to Inventories and vice versa.
    public static Inventory Deserialize(string inventoryString)     // Converts String into Inventories
    {
        return ToInventory(ToItemList(inventoryString));
    }

    public static string? Serialize(Inventory inventory)            // Converts Inventories into String
    {
        return ToString(ToItemList(inventory)!);
    }

    public static Inventory DeserializeList(List<string> itemArray)     // Converts String into Inventories
    {
        Inventory inventory = new();
        foreach (string item in itemArray)
        {
            inventory.Items!.Add(new(item));
        }
        return inventory;
    }

    public static List<string>? SerializeList(Inventory inventory)            // Converts Inventories into String
    {
        List<string> itemArray = new();
        foreach (Item item in inventory.Items!)
        {
            itemArray.Add(item.ID);
        }
        return itemArray;
    }

    private static List<Item> ToItemList(string itemString)         //Converts String into List<Item>
    {
        List<Item> itemList = [];

        string[] items = itemString.Split('|');

        foreach (string item in items)
            itemList.Add(new Item(item));

        return itemList;
    }

    private static string ToString(List<Item> items)                // Converts List<Item> to String
    {
        if (items == null)
            return "";
        else
        {
            string inventory = "";

            foreach (Item item in items)
            {
                if (inventory == "")
                    inventory += StringHelper.ToItemIdFormat(item.ID);
                else
                    inventory += "|" + StringHelper.ToItemIdFormat(item.ID);
            }

            return inventory;
        }
    }

    private static Inventory ToInventory(List<Item> itemList)       // Converts List<Item> to Inventories
    {
        return new(itemList);
    }

    private static List<Item>? ToItemList(Inventory inventory)      // Converts Inventories to List<Item>
    {
        return inventory.Items;
    }
}
