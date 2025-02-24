﻿using w5_assignment_ksteph.Commands;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Entities.Monsters;

public class Cleric : Monster, IHeal, ICastable
{
    // An Cleric unit that is able to heal and cast spells.

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
