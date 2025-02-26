using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.Items.WeaponItems;

namespace w5_assignment_ksteph.Inventories;
public class Inventory
{
    // The Inventory class holds a list of items.
    public IEntity Unit;
    public List<Item>? Items { get; set; } = new();

    public Inventory()
    {

    }
    public Inventory(IEntity unit)
    {
        Unit = unit;
    }
    public Inventory(List<Item> items)
    {
        Items = items;
    }

    public bool AddItem(Item item)
    {
        if (Items!.Count < 5)
        {
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

    public override string ToString() => InventorySerializer.Serialize(this)!;
}
