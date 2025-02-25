using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Commands.UnitCommands;

namespace w5_assignment_ksteph.Interfaces.Behaviors.CharacterBehaviors;

public interface IFlyable
{
    // Interface tha allows units to fly.
    CommandInvoker Invoker { set; get; }
    FlyCommand FlyCommand { set; get; }
    void Fly(Position position);
}
