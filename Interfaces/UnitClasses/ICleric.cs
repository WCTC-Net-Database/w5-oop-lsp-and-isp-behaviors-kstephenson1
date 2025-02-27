using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;

namespace w5_assignment_ksteph.Interfaces.UnitClasses;

public interface ICleric : IHeal, ICastable
{
    // An Cleric unit that is able to heal and cast spells.

}
