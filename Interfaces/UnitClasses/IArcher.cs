using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.Behaviors;

namespace w5_assignment_ksteph.Entities.Monsters;

public interface IArcher : IShootable
{
    // An Archer unit that is able to shoot.
    public ShootCommand ShootCommand { get; set; }

    public void Shoot(IEntity target);

    public void Attack(IEntity target) => Shoot(target);
}
