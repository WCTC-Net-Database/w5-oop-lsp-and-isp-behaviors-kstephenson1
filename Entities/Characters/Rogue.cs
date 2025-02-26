using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities.Characters;

public class Rogue : Character
{
    // An Fighter unit that is able to fight.
    public Rogue()
    {
        Inventory.Unit = this;
    }
    public Rogue(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
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
