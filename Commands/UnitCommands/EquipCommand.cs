using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;
using w5_assignment_ksteph.Items;
using w5_assignment_ksteph.Items.WeaponItems;

namespace w5_assignment_ksteph.Commands.UnitCommands;

public class EquipCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly WeaponItem _item;
    public EquipCommand(IEntity unit, WeaponItem item)
    {
        _item = item;
    }
    public void Execute()
    {
        _unit.Equip(_item);
    }
}
