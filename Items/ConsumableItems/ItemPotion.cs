using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w5_assignment_ksteph.Items.ConsumableItems;

public class ItemPotion : Item, IConsumableItem
{
    public int MaxUses { get; set; }
    public int UsesLeft { get; set; }
    public ItemPotion(string id) : base(id)
    {
        UsesLeft = MaxUses;
    }

    public ItemPotion(string id, string name) : base(id, name)
    {
        UsesLeft = MaxUses;
    }

    public void BreakItem()
    {
        Inventory.RemoveItem(this);
    }

    public void TakeItemDamage()
    {
        throw new NotImplementedException();
    }

    public void UseItem()
    {
        if (Inventory.Unit.HitPoints >= Inventory.Unit.MaxHitPoints)
        {
            Console.WriteLine($"{Inventory.Unit.Name} is already at max health.");
        }
        else
        {
            Inventory.Unit.HitPoints += 10;
            UsesLeft--;
        }
    }
}
