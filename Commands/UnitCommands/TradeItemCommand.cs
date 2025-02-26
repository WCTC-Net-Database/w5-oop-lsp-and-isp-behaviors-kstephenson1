using w5_assignment_ksteph.Combat;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.Items;

namespace w5_assignment_ksteph.Commands.UnitCommands;

public class TradeItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly Item _item;
    private readonly IEntity _target;
    public TradeItemCommand(IEntity unit, Item item, IEntity target)
    {
        _unit = unit;
        _item = item;
        _target = target;
    }
    public void Execute()
    {
        _unit.TradeItem(_item, _target);
    }
}
