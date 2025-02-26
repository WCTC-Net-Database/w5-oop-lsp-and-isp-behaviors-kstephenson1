using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands.UnitCommands;

namespace w5_assignment_ksteph.Interfaces.CharacterBehaviors;

public interface ICastable
{
    // Interface tha allows units to cast spells.
    CommandInvoker Invoker { set; get; }
    CastCommand CastCommand { set; get; }
    void Cast(string spellName);
}
