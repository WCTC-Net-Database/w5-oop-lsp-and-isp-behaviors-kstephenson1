using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class ShootCommand : ICommand
{
    private readonly IEntity _unit;
    private readonly IEntity _target;
    private readonly EncounterStats _encounter;
    public ShootCommand(EncounterStats encounter)
    {
        _unit = encounter.Unit;
        _target = encounter.Target;
        _encounter = encounter;
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
