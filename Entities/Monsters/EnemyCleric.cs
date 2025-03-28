﻿using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.UnitClasses;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities.Monsters;

public class EnemyCleric : Monster, ICleric
{
    // An Cleric unit that is able to heal and cast spells.
    public EnemyCleric()
    {
        Inventory.Unit = this;
    }

    public EnemyCleric(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
        Position = position;
        Inventory.Unit = this;
    }

    public HealCommand HealCommand { get; set; } = null!;
    public CastCommand CastCommand { get; set; } = null!;

    public void Heal(IEntity target)
    {
        HealCommand = new(this, target);
        Invoker.ExecuteCommand(HealCommand);
    }
    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);

    }
}
