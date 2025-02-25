using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces.Behaviors.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.Behaviors.InventoryBehaviors;

namespace w5_assignment_ksteph.Interfaces;

public interface IEntity : IAttackable, IAttack, IInventory, IHaveStats
{
    // Interface tha allows units to exist.
    MoveCommand MoveCommand { set; get; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    Position Position { get; set; }

    void Move(Position position);
    string GetHealthBar();
}
