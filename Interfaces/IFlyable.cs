using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.DataTypes.Structs;

namespace w5_assignment_ksteph.Interfaces;

public interface IFlyable
{
    // Interface tha allows units to fly.
    CommandInvoker Invoker { set; get; }
    FlyCommand FlyCommand { set; get; }
    void Fly(Position position);
}
