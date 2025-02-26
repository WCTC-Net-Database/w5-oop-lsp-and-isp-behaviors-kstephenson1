using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities.Monsters;

public class EnemyGhost : Monster, IFlyable
{
    // A Ghost unit that is able fly.
    public EnemyGhost()
    {
        Inventory.Unit = this;
    }

    public EnemyGhost(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
        Position = position;
        Inventory.Unit = this;
    }
    public FlyCommand FlyCommand { get ; set ; } = null!;

    public void Fly(Position position)
    {
        FlyCommand = new(this, position);
        Invoker.ExecuteCommand(FlyCommand);
    }

    public override void Move(Position position) => Fly(position);

}
