using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Ghost : Monster, IFlyable
{

    public void Fly(Position position)
    {
        Console.WriteLine($"{Name} soars through the air to {position.ToString}");
    }

}
