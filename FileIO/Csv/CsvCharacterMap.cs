using CsvHelper.Configuration;

namespace w4_assignment_ksteph.FileIO.Csv;

public class CsvCharacterMap : ClassMap<Characters.Character>
{
    // The CsvCharacterMap is an extension of CsvHelper that assists turning the csv file into a character.
    // This class allows the inventory to be imported as a custom Inventories object instead of a string with
    // the help of the InventoryConverter
    public CsvCharacterMap()
    {
        Map(character => character.Name);
        Map(character => character.Class);
        Map(character => character.Level);
        Map(character => character.HitPoints);
        Map(character => character.Inventory).TypeConverter(new CsvInventoryConverter());
    }
}
