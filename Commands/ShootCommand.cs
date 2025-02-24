using w5_assignment_ksteph.Combat;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class ShootCommand : ICommand
{
    // The ShootCommand takes an attacking unit and a target, checks to see if the unit is able to shoot, then shoots at the target if available,
    // using an Encounter to calculate the damage and hit/crit chances.

    private readonly IEntity _unit;
    private readonly IEntity _target;
    private readonly Encounter _encounter;
    public ShootCommand(IEntity unit, IEntity target)
    {
        _unit = unit;
        _target = target;
        _encounter = new(unit, target, 1, 4, 70, 5);
    }

    public void Execute()
    {
        if (_encounter.Unit is IShootable)
        {
            Console.WriteLine($"{_unit.Name} fires at {_target.Name}");

            if (_encounter.IsCrit())
            {
                int damage = _encounter.RollDamage();
                Console.WriteLine($"{_unit.Name} critically hit {_target.Name} for {damage} damage!");
                _target.TakeDamage(damage);
            }
            else if (_encounter.IsHit())
            {
                int damage = _encounter.RollDamage();
                Console.WriteLine($"{_unit.Name} hit {_target.Name} for {_encounter.RollDamage()} damage.");
                _target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine($"{_unit.Name}'s misses {_target.Name}");
            }
        } else
        {
            Console.WriteLine($"{_encounter.Unit.Name} cannot use the shoot action.");
        }
    }
}
