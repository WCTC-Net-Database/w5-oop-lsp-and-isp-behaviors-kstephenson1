using w5_assignment_ksteph.FileIO;

namespace w5_assignment_ksteph.Inventories;
public class Inventory
{
    // The Inventory class holds a list of items.

    public List<Item>? Items { get; set; } = new();

    public Inventory() { }
    public Inventory(List<Item> items)
    {
        Items = items;
    }

    public void AddItem(Item item)
    {
        Items!.Add(item);
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

    public override string ToString() => InventorySerializer.Serialize(this)!;
}
