using w5_assignment_ksteph.Combat;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.Items;

namespace w5_assignment_ksteph.Commands.UnitCommands;

public class DropItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly Item _item;

    public DropItemCommand(IEntity unit, Item item)
    {
        _unit = unit;
        _item = item;
    }
    public void Execute()
    {
        _unit.DropItem(_item);
    }
}
