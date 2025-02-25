namespace w5_assignment_ksteph.FileIO;

using w5_assignment_ksteph.FileIO.Csv;
using w5_assignment_ksteph.FileIO.Json;
using w5_assignment_ksteph.Config;
using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;
using w5_assignment_ksteph.Inventories;
using w5_assignment_ksteph.Interfaces.Behaviors.ItemBehaviors;

public class FileManager<TType>
{
    // FileManager contains redirects to functions that assist with file IO functions.  This class allows the import and export of a generic
    // unit type.

    private static FileType _fileType = Config.DEFAULT_FILE_TYPE;

    private Type _type = typeof(TType);
    private Dictionary<Type, int> _typeDict = new Dictionary<Type, int>
        {
            {typeof(Character),0},
            {typeof(Monster),1},
            {typeof(Item),2},
        };

    private string GetFilePath()
    {
        return _typeDict[_type] switch
        {
            0 => "Files/characters",
            1 => "Files/monsters",
            2 => "Files/weapons",
            _ => throw new ArgumentOutOfRangeException($"GetFilePath() has invalid type ({_typeDict})")
        };

    }

    private static ICharacterIO GetFileType<Ttype>() // Checks to see what the current file type is set to and execute the proper file system.
    {
        return _fileType switch
        {
            FileType.Csv => new CsvFileHandler<Ttype>(),
            FileType.Json => new JsonFileHandler<Ttype>(),
            _ => throw new NullReferenceException("Error: File type not found in FileManager.GetFileType()"),
        };
    }
    private static IItemIO GetFileType() // Checks to see what the current file type is set to and execute the proper file system.
    {
        return _fileType switch
        {
            FileType.Csv => new CsvFileHandler<Item>(),
            FileType.Json => new JsonFileHandler<Item>(),
            _ => throw new NullReferenceException("Error: File type not found in FileManager.GetFileType()"),
        };
    }

    public static void SwitchFileType()
    {
        Console.Clear();
        if (_fileType == FileType.Csv)
        {
            Console.WriteLine("File format set to Json.");
            _fileType = FileType.Json;
        } else
        {
            Console.WriteLine("File format set to Csv.");
            _fileType = FileType.Csv;
        }
    }

    public List<Ttype> ImportUnits<Ttype>() => GetFileType<Ttype>().ReadUnits<Ttype>(GetFilePath());
    public void ExportUnits<Ttype>(List<Ttype> units) => GetFileType<Ttype>().WriteUnits(units, GetFilePath());
    public List<Item> ImportItems() => GetFileType().ReadItems(GetFilePath());
    public void ExportItems(List<Item> items) => GetFileType().WriteItems(items, GetFilePath());
}
