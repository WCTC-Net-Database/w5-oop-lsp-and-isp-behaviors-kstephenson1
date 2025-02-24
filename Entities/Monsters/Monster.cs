using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.UI;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Monster : Unit
{
    // The Monster class is, for the most part, an abstract(ish) class that might contain some computer intelligence functions one day.
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
