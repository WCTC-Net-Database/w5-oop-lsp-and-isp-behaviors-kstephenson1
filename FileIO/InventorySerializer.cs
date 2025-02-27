﻿namespace w5_assignment_ksteph.FileIO;

using System.Collections.Generic;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.Interfaces;
using System.Text.Json;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel;
using w5_assignment_ksteph.Items.WeaponItems;
using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.Items.ConsumableItems;

public class InventorySerializer
{
    // InventorySerializer contains fuctions to turn a string into List<Item> to Inventories and vice versa.
    public static Inventory Deserialize(string inventoryString)         // Converts String into Inventories
    {
        return ToInventory(ToItemList(inventoryString));
    }

    public static string? Serialize(Inventory inventory)                // Converts Inventories into String
    {
        return ToString(ToItemList(inventory)!);
    }

    public static Inventory DeserializeList(List<string> itemArray)     // Converts String into Inventories
    {
        Inventory inventory = new();
        foreach (string item in itemArray)
        {
            var convertedItem = ConvertToItem(item);
            inventory.Items!.Add(convertedItem);
        }
        return inventory;

        //Inventory inventory = new();
        //foreach (string item in itemArray)
        //{
        //    inventory.Items!.Add(new Item(item));
        //}
        //return inventory;
    }

    public static List<string>? SerializeList(Inventory inventory)      // Converts Inventories into String
    {
        List<string> itemArray = new();
        foreach (Item item in inventory.Items!)
        {
            itemArray.Add(item.ID);
        }
        return itemArray;
    }

    private static List<IItem> ToItemList(string itemString)             //Converts String into List<Item>
    {
        List<IItem> itemList = [];

        string[] items = itemString.Split('|');

        foreach (string item in items)
            itemList.Add(new Item(item));

        return itemList;
    }

    private static string ToString(List<IItem> items)                    // Converts List<Item> to String
    {
        if (items == null)
            return "";
        else
        {
            string inventory = "";

            foreach (IItem item in items)
            {
                if (inventory == "")
                    inventory += StringHelper.ToItemIdFormat(item.ID);
                else
                    inventory += "|" + StringHelper.ToItemIdFormat(item.ID);
            }

            return inventory;
        }
    }

    private static Inventory ToInventory(List<IItem> itemList)           // Converts List<Item> to Inventories
    {
        return new(itemList);
    }

    private static List<IItem>? ToItemList(Inventory inventory)          // Converts Inventories to List<Item>
    {
        return inventory.Items;
    }

    private static IItem ConvertToItem(string itemString)
    {
        return itemString switch
        {
            // Weapons
            "dagger" => new WeaponItem("dagger", "Dagger", WeaponType.Sword, WeaponRank.E, 45, 8, 80, 0, 1, 4, 1),
            "mace" => new WeaponItem("mace", "Mace", WeaponType.Axe, WeaponRank.E, 45, 8, 80, 0, 1, 4, 1),
            "staff" => new WeaponItem("staff", "Staff", WeaponType.Lance, WeaponRank.E, 45, 8, 80, 0, 1, 4, 1),
            "sword" => new WeaponItem("sword", "Sword", WeaponType.Sword, WeaponRank.E, 45, 8, 80, 0, 1, 4, 1),

            // Consumables
            "potion" => new ItemPotion(),
            "book" => new ItemBook(),
            "lockpick" => new ItemLockpick(),

            _ => new WeaponItem($"{itemString}", $"TestItem {itemString}", WeaponType.None, WeaponRank.E, 1, 0, 0, 0, 0, 0, 0)
        };
    }
}
