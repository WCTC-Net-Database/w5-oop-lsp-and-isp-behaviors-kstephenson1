﻿using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands.UnitCommands;

namespace w5_assignment_ksteph.Interfaces.CharacterBehaviors;

public interface IHeal
{
    // Interface tha allows units to heal.
    CommandInvoker Invoker { set; get; }
    HealCommand HealCommand { set; get; }

    void Heal(IEntity target);
}
