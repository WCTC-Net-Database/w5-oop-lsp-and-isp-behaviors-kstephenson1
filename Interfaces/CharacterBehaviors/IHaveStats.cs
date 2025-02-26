using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Combat;

namespace w5_assignment_ksteph.Interfaces.CharacterBehaviors;

public interface IHaveStats
{
    // Interface that requires units to have stats.
    public UnitStats Stats { get; set; }
}
