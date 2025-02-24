using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Monster : Unit
{
    public Monster() { }

    public Monster(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
    }
}
