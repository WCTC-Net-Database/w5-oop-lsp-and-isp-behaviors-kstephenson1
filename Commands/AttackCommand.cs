using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class AttackCommand : ICommand
{
    private readonly IEntity _unit;
    private readonly IEntity _target;
    private readonly EncounterStats _encounter;
    public AttackCommand(EncounterStats encounter)
    {
        _unit = encounter.Unit;
        _target = encounter.Target;
        _encounter = encounter;
    }
    public void Execute()
    {
        if (_unit is IAttack)
        {
            Console.WriteLine($"{_unit.Name} attacks {_target.Name}");

            if (_encounter.IsCrit())
            {
                Console.WriteLine($"{_unit.Name} critically hit {_target.Name} for {_encounter.RollDamage()} damage!");
            }
            else if (_encounter.IsHit())
            {
                Console.WriteLine($"{_unit.Name} hit {_target.Name} for {_encounter.RollDamage()} damage.");
            }
            else
            {
                Console.WriteLine($"{_unit.Name}'s misses {_target.Name}");
            }
        } else
        {
            Console.WriteLine($"{_unit} cannot attack.");
        }
        
    }
}
