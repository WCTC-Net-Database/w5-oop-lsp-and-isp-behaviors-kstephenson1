using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities;

public abstract class Entity : IEntity
{
    public int Id { get; set; }
    public virtual string Name { get; set; }

    public virtual void Attack(IEntity target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");
    }

    public virtual void Move()
    {
        Console.WriteLine($"{Name} moves.");
    }
}
