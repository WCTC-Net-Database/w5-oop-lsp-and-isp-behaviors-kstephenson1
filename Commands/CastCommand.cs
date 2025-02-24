using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.Behaviors;

namespace w5_assignment_ksteph.Commands;

public class CastCommand : ICommand
{
    // The CastCommand takes in a casting unit and a spell name.  If the unit is a caster, it will cast the spell.

    private readonly IEntity _unit;
    private readonly string _spellName;
    public CastCommand(IEntity unit, string spellName)
    {
        _unit = unit;
        _spellName = spellName;
    }
    public void Execute()
    {
        if (_unit is ICastable)
        {
            Console.WriteLine($"{_unit.Name} casts {_spellName}");
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot cast spells.");
        }
    }
}
