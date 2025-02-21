using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using w4_assignment_ksteph.FileIO;

namespace w4_assignment_ksteph.FileIO.Csv;

// The CsvInventoryConverter is used to turn the inventory string into an Inventories Object automatically.
public class CsvInventoryConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        return InventorySerializer.Deserialize(text!);
    }
}
