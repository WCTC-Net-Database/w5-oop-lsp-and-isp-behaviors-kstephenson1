using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Interfaces.InventoryBehaviors;

public interface IHaveInventory
{
    // Interface tha allows units to hold items.
    public Inventory Inventory { get; set; }
}
