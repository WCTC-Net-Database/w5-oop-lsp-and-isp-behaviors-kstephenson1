using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Interfaces.Behaviors;

namespace w5_assignment_ksteph.Entities.Monsters;

public interface IMage : ICastable
{
    // A Mage unit that is able to cast spells.
    public CastCommand CastCommand { get; set; }

    public void Cast(string spellName);
}
