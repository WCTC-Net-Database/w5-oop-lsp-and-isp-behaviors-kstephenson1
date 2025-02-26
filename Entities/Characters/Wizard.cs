using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.Entities.Monsters;

namespace w5_assignment_ksteph.Entities.Characters;

public class Wizard : Character, IMage
{
    // A Mage unit that is able to cast spells.
    public CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);
    }
}
