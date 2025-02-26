
namespace w5_assignment_ksteph.Interfaces.ItemBehaviors;

public interface IConsumableItem
{
    public int MaxUses { get; set; }
    public int UsesLeft { get; set; }
    public void UseItem(IEntity itemUser, IEntity itemTarget);
    public void TakeItemDamage();
    public void BreakItem();
}
