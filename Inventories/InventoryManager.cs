namespace w4_assignment_ksteph.Inventories;

using w4_assignment_ksteph.UI;

public class InventoryManager
{
    // InventoryManager holds methods that have to do with manipulating inventories.
    [Obsolete]
    public static void ListInventory(Inventory inventory) => InventoryUI.DisplayInventory(inventory);
}
