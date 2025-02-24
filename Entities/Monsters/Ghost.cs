using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Ghost : Monster, IFlyable
{
    public FlyCommand FlyCommand { get ; set ; } = null!;

    public void Fly(Position position)
    {
        FlyCommand = new(this, position);
        Invoker.ExecuteCommand(FlyCommand);
    }

    public override void Move(Position position) => Fly(position);

}
