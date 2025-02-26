using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.FileIO;

public interface IItemIO : IFileIO
{
    new public List<TItem> Read<TItem>(string dir);
    new public void Write<TItem>(List<TItem> items, string dir);
}
