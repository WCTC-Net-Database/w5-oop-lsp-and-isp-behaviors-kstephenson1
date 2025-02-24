using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Interfaces;

public interface IInventory
{
    // Interface tha allows units to hold items.
    Inventory Inventory { get; set; }
}
