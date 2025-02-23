using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities;

public abstract class Unit : IEntity, IAttackable, IAttack, IInventory
{
    public virtual required string Name { get; set; }
    public virtual required string Class { get; set; }
    public virtual int Level { get; set; }
    public virtual int MaxHitPoints { get; set; }
    public virtual int HitPoints { get; set; }
    public virtual Inventory Inventory { get; set; } = new();
    public virtual Position Position { get; set; } = new();

    public virtual void Attack(IEntity target)
    {
        throw new NotImplementedException();
    }

    public virtual void Move()
    {
        Console.WriteLine($"{Name} moves.");
    }

    public void Move(Position position)
    {
        throw new NotImplementedException();
    }

    public void OnDamageTaken()
    {
        throw new NotImplementedException();
    }

    public void OnDeath()
    {
        throw new NotImplementedException();
    }
}
