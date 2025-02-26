using w5_assignment_ksteph.Combat;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w5_assignment_ksteph.Commands.UnitCommands;

public class UseItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly IConsumableItem _item;
    public UseItemCommand(IEntity unit, IConsumableItem item)
    {
        _unit = unit;
        _item = item;
    }
    public void Execute()
    {
        _item.UseItem();
    }
}
