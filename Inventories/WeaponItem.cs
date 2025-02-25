using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.Interfaces.Behaviors.ItemBehaviors;

namespace w5_assignment_ksteph.Inventories;

public class WeaponItem : Item, IWeaponItem
{
    // Item is a class that holds item information.

    public WeaponType WeaponType { get; set; }
    public WeaponRank RequiredRank { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public int Might { get; set; }
    public int Hit {  get; set; }
    public int Crit {  get; set; }
    public int Range { get; set; }
    public int Weight { get; set; }
    public int ExpModifier { get; set; }

    public WeaponItem(string id, string name, WeaponType weaponType, WeaponRank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(id)
    {
        MaxDurability = maxDurability;  WeaponType = weaponType;    Name = name;
        RequiredRank = requiredRank;    Weight = weight;            Crit = crit;
        Durability = maxDurability;     Range = range;              Hit = hit;
        ExpModifier = expModifier;      Might = might;              ID = id;
    }

    public override string ToString()
    {
        return ID;
    }

    public void Equip()
    {
        throw new NotImplementedException();
    }

    public void TakeDurabilityDamage(int durabilityDamage)
    {
        throw new NotImplementedException();
    }

    public void BreakItem()
    {
        throw new NotImplementedException();
    }
}
