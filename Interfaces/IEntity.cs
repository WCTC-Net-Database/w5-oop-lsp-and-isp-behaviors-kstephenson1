using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces.Behaviors;
using w5_assignment_ksteph.UI;

namespace w5_assignment_ksteph.Interfaces;

public interface IEntity : IAttackable, IAttack, IInventory
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
