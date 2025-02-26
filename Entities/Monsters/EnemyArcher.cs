using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class EnemyArcher : Monster, IArcher
{
    public EnemyArcher()
    {

    }
    // An Archer unit that is able to shoot.
    public ShootCommand ShootCommand { get; set; }

    public void Shoot(IEntity target)
    {
        ShootCommand = new(this, target);
        Invoker.ExecuteCommand(ShootCommand);
    }

    public override void Attack(IEntity target) => Shoot(target);
}
