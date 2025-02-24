using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands;

namespace w5_assignment_ksteph.Interfaces;

public interface ICastable
{
    // Interface tha allows units to cast spells.
    CommandInvoker Invoker { set; get; }
    CastCommand CastCommand { set; get; }
    void Cast(string spellName);
}
