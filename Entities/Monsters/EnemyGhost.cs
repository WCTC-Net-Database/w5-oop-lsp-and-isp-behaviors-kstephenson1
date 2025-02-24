using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces.Behaviors;

namespace w5_assignment_ksteph.Entities.Monsters;

public class EnemyGhost : Monster, IFlyable
{
    // A Ghost unit that is able fly.
    public FlyCommand FlyCommand { get ; set ; } = null!;

    public void Fly(Position position)
    {
        FlyCommand = new(this, position);
        Invoker.ExecuteCommand(FlyCommand);
    }

    public override void Move(Position position) => Fly(position);

}
