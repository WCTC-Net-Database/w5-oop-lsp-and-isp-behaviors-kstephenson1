using w4_assignment_ksteph.FileIO;

namespace w4_assignment_ksteph.Inventories;
public class Inventory
{
    public List<Item>? Items { get; set; } = new();

    public Inventory() { }
    public Inventory(List<Item> items)
    {
        Items = items;
    }

    public override string ToString() => InventorySerializer.Serialize(this)!;
}
