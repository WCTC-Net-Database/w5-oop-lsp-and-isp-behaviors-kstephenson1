using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Archer : Monster, IShootable
{
    public ShootCommand ShootCommand { get; set; }

    public void Shoot(IEntity target)
    {
        ShootCommand = new(this, target);
        Invoker.ExecuteCommand(ShootCommand);
    }

    public override void Attack(IEntity target) => Shoot(target);
}
