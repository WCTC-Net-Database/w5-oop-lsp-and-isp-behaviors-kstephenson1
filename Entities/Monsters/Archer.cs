using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Archer : Monster, IShootable
{
    public void Shoot(IEntity target)
    {
        throw new NotImplementedException();
    }
}
