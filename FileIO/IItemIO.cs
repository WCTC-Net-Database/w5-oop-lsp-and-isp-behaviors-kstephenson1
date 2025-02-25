using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.FileIO;

public interface IItemIO
{
    public List<Item> ReadItems(string dir);
    public void WriteItems(List<Item> items, string dir);
}
