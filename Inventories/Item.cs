using w5_assignment_ksteph.DataHelper;

namespace w5_assignment_ksteph.Inventories;

public class Item
{
    // Item is a class that holds item information.

    public string Name { get; set; }
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
