using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Mage : Monster, ICastable
{
    public CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, "fireball");
        Invoker.ExecuteCommand(CastCommand);
    }
}
