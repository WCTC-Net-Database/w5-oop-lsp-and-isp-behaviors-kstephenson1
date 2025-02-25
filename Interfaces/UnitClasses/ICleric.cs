using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.Behaviors.CharacterBehaviors;

namespace w5_assignment_ksteph.Entities.Monsters;

public interface ICleric : IHeal, ICastable
{
    // An Cleric unit that is able to heal and cast spells.

    public HealCommand HealCommand { get; set; }
    public CastCommand CastCommand { get; set; }

    public void Heal(IEntity target);
    public void Cast(string spellName);
}
