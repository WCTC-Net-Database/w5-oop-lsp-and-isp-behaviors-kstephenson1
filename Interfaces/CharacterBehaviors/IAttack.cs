using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands.UnitCommands;

namespace w5_assignment_ksteph.Interfaces.CharacterBehaviors;

public interface IAttack
{
    // Interface tha allows units to attack.
    CommandInvoker Invoker { set; get; }
    AttackCommand AttackCommand { set; get; }

    void Attack(IEntity target);
}
