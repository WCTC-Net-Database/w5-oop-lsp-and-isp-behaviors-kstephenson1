using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands;

namespace w5_assignment_ksteph.Interfaces;

public interface IAttack
{
    // Interface tha allows units to attack.
    CommandInvoker Invoker { set; get; }
    AttackCommand AttackCommand { set; get; }

    void Attack(IEntity target);
}
