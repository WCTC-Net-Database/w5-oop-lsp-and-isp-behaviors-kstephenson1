using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.Entities;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w5_assignment_ksteph.Items.ConsumableItems;

public class ItemBook : Item, IConsumableItem
{
    public int MaxUses { get; set; } = 10;
    public int UsesLeft { get; set; }
    public ItemBook()
    {
        ID = "book";
        Name = StringHelper.ToItemNameFormat(ID);
        Description = "It's a book.";
        UsesLeft = MaxUses;
    }

    public ItemBook(string id, string name) : base(id, name)
    {
        UsesLeft = MaxUses;
    }

    public void UseItem()
    {
        Console.WriteLine($"You read the book.  Aren't you in combat right now?");
    }
}
