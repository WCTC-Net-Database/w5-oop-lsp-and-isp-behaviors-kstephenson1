using w5_assignment_ksteph.FileIO;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.Items.ConsumableItems;
using w5_assignment_ksteph.Items.WeaponItems;

namespace w5_assignment_ksteph.Inventories;

public static class ItemUtilities
{
    // The ItemManager class is a static class that holds lists of items for reference.

    public static void DisplayItems()                                           //Displays each item's information.
    {
        Console.Clear();

        foreach (Item item in ItemManager.Items)
        {
            Console.WriteLine(item.Name);
        }
    }

}
