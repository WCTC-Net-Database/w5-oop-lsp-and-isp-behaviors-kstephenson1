using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Ghost : Monster, IFlyable
{
    public void Fly()
    {
        Console.WriteLine($"{Name} soars through the air.");
    }
}
