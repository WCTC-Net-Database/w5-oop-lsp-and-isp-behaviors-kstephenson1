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
        throw new NotImplementedException();
    }

    public void TakeItemDamage()
    {
        throw new NotImplementedException();
    }

    public void UseItem(IEntity itemUser, IEntity itemTarget)
    {
        throw new NotImplementedException();
    }
}
