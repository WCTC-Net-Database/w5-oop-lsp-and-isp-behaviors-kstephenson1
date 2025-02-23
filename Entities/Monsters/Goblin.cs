using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Goblin : Monster
{
    public override void Attack(IEntity target)
    {
        Console.WriteLine($"{Name} slashes {target.Name}");
    }
}
