using w5_assignment_ksteph.Interfaces.Behaviors.ItemBehaviors;

namespace w5_assignment_ksteph.Interfaces.Behaviors.InventoryBehaviors;

public interface IEquippableInventory : IInventory
{
    public IWeaponItem GetEquippedItem();
    public void SetEquippedItem(IWeaponItem item);
    public void ItemTakesDurabilityDamage(IWeaponItem item);
}
