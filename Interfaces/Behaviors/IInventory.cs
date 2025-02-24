using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Interfaces.Behaviors;

public interface IInventory
{
    // Interface tha allows units to hold items.
    Inventory Inventory { get; set; }
}
