using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class CastCommand : ICommand
{
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
