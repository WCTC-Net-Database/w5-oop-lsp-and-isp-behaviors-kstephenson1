﻿using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w5_assignment_ksteph.Items.ConsumableItems;

public class ItemPotion : Item, IConsumableItem
{
    public int MaxUses { get; set; } = 3;
    public int UsesLeft { get; set; }
    public ItemPotion()
    {
        ID = "potion";
        Name = StringHelper.ToItemNameFormat(ID);
        Description = "Use to restore 10 hp.";
        UsesLeft = MaxUses;
    }

    public ItemPotion(string id, string name) : base(id, name)
    {
        UsesLeft = MaxUses;
    }

    public void UseItem()
    {
        if (Inventory.Unit!.HitPoints >= Inventory.Unit.MaxHitPoints)
        {
            Console.WriteLine($"{Inventory.Unit.Name} is already at max health.");
        }
        else
        {
            int preItemHP = Inventory.Unit.HitPoints;
            Inventory.Unit.Heal(10);
            int postItemHP = Inventory.Unit.MaxHitPoints;
            int healedHP = postItemHP - preItemHP;
            Console.WriteLine($"{Inventory.Unit.Name} used {Name} and gained {healedHP} hit points");
            UsesLeft--;

            if (UsesLeft == 0)
            {
                Inventory.RemoveItem(this);
            }
        }
    }
}
