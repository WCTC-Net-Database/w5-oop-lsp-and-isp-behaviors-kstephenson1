﻿using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands.ItemCommands;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Interfaces.InventoryBehaviors;

public interface IHaveInventory
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    DropItemCommand DropItemCommand { get; set; }
    TradeItemCommand TradeItemCommand { get; set; }
    Inventory Inventory { get; set; }
    void DropItem(IItem item);
    void TradeItem(IItem item);
}
