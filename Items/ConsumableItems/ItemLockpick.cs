using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w5_assignment_ksteph.Items.ConsumableItems;

public class ItemLockpick : Item, IConsumableItem
{
    public int MaxUses { get; set; } = 3;
    public int UsesLeft { get; set; }
    public ItemLockpick()
    {
        ID = "lockpick";
        Name = StringHelper.ToItemNameFormat(ID);
        Description = "Use to unlock a nearby door or chest.";
        UsesLeft = MaxUses;
    }

    public ItemLockpick(string id, string name) : base(id, name)
    {
        UsesLeft = MaxUses;
    }

    public void UseItem()
    {
        Console.WriteLine($"{Inventory.Unit!.Name} unlocked something!");
        UsesLeft--;

        if (UsesLeft == 0)
        {
            Console.WriteLine($"The lockpick broke!");
            Inventory.RemoveItem(this);
        }
    }
}
