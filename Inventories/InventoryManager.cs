namespace w5_assignment_ksteph.Inventories;

using w5_assignment_ksteph.UI;

public class InventoryManager
{
    // InventoryManager holds methods that have to do with manipulating inventories.  Might be implemented later.
    [Obsolete]
    public static void ListInventory(Inventory inventory) => InventoryUI.DisplayInventory(inventory);
}
