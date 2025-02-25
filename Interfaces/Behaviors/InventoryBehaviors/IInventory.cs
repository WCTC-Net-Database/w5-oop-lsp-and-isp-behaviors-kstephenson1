using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Interfaces.Behaviors.InventoryBehaviors;

public interface IInventory
{
    // Interface tha allows units to hold items.
    public Inventory Inventory { get; set; }
}
