using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands;

namespace w5_assignment_ksteph.Interfaces;

public interface ICastable
{
    CommandInvoker Invoker { set; get; }
    CastCommand CastCommand { set; get; }
    void Cast(string spellName);
}
