﻿using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.InventoryBehaviors;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Interfaces;

public interface IItem
{
    // Interface tha allows items to exist.
    public string Name { get; set; }
    public string Description { get; set; }
    public string ID { get; set; }
    Inventory Inventory { get; set; }
}
