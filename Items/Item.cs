using w5_assignment_ksteph.DataHelper;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Items;

public class Item : IItem
{
    // Item is a class that holds item information.
    public Inventory Inventory { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ID { get; set; }

    public Item(string id)
    {
        ID = StringHelper.ToItemIdFormat(id);
        Name = StringHelper.ToItemNameFormat(id);
    }

    public Item(string id, string name)
    {
        ID = StringHelper.ToItemIdFormat(id);
        Name = StringHelper.ToItemNameFormat(name);
    }

    public override string ToString()
    {
        return ID;
    }
}
