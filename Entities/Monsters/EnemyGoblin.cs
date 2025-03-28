﻿using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities.Monsters;

public class EnemyGoblin : Monster
{
    // A Goblin unit that has no special implementation. . . yet?
    public EnemyGoblin()
    {
        Inventory.Unit = this;
    }

    public EnemyGoblin(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
        Position = position;
        Inventory.Unit = this;
    }
}
