using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands;

namespace w5_assignment_ksteph.Interfaces;

public interface IAttack
{
    CommandInvoker Invoker { set; get; }
    AttackCommand AttackCommand { set; get; }

    void Attack(IEntity target);
}
