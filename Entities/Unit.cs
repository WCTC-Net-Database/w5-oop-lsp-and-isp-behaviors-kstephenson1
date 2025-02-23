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
        Console.WriteLine($"{Name} attacks {target.Name}");
    }

    public virtual void Move(Position position)
    {
        Console.WriteLine($"{Name} moves to {position.ToString}");
    }

    public virtual void TakeDamage(int damage)
    {
        HitPoints -= damage;
        OnDamageTaken();

        if (IsDead())
            OnDeath();
    }

    public virtual void OnDamageTaken()
    {

    }

    public virtual void OnDeath()
    {

    }

    public bool IsDead()
    {
        return HitPoints <= 0 ? true : false;
    }


}
