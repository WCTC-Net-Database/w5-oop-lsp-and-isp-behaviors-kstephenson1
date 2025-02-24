using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands;

namespace w5_assignment_ksteph.Interfaces;

public interface IShootable
{
    CommandInvoker Invoker { set; get; }
    ShootCommand ShootCommand { set; get; }
    void Shoot(IEntity target);
}
