using System.Text.Json.Serialization;
using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.Items.WeaponItems;

namespace w5_assignment_ksteph.Inventories;
public class Inventory
{
    // The Inventory class holds a list of items.
    [JsonIgnore]
    public IEntity Unit;
    public List<Item>? Items { get; set; } = new();

    public Inventory()
    {
        //SetParentsInItems();
    }
    public Inventory(List<Item> items)
    {
        Items = items;
        //SetParentsInItems();
    }

    public bool AddItem(Item item)
    {
        if (Items!.Count < 5)
        {
            SetParentsInItem(item);
            Items!.Add(item);
            return true;
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        try
        {
            Items!.Remove(item);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool IsEquipped(out WeaponItem? weapon)
    {
        foreach(Item item in Items!)
        {
            if (item is WeaponItem)
            {
                weapon = (WeaponItem)item;
                return true;
            }
        }
        weapon = null;
        return false;
    }

    public void SetEquippedItem(WeaponItem item)
    {

    }
    public bool DamageEquippedItem()
    {
        if (IsEquipped(out WeaponItem? weapon))
        {
            weapon!.TakeDurabilityDamage(1);
            return true;
        }
        else
            return false;
    }

    public List<IConsumableItem> GetConsumableItems()
    {
        List<IConsumableItem> consumableItems = new();
        foreach (Item item in Items!)
        {
            if (item is IConsumableItem)
            {
                consumableItems.Add((IConsumableItem)item);
            }
        }

        return consumableItems;
    }

    private void SetParentsInItems()
    {
        foreach (var item in Items!)
        {
            item.Inventory = this;
        }
    }

    private void SetParentsInItem(Item item)
    {
        item.Inventory = this;
    }

    public override string ToString() => InventorySerializer.Serialize(this)!;
}
