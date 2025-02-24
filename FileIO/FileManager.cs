namespace w5_assignment_ksteph.FileIO;

using w5_assignment_ksteph.FileIO.Csv;
using w5_assignment_ksteph.FileIO.Json;
using w5_assignment_ksteph.Config;
using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;

public class FileManager<TTUnit>
{
    // FileManager contains redirects to functions that assist with file IO functions.  This class allows the import and export of a generic
    // unit type.

    private static FileType _fileType = Config.DEFAULT_FILE_TYPE;

    private Type _unitType = typeof(TTUnit);
    private Dictionary<Type, int> _unitTypeDict = new Dictionary<Type, int>
        {
            {typeof(Character),0},
            {typeof(Monster),1},
        };

    private string GetFilePath()
    {
        return _unitTypeDict[_unitType] switch
        {
            0 => "Files/characters",
            1 => "Files/monsters",
            _ => throw new ArgumentOutOfRangeException($"GetFilePath() has invalid type ({_unitTypeDict})")
        };

    }

    private static ICharacterIO GetFileType<TUnit>() // Checks to see what the current file type is set to and execute the proper file system.
    {
        return _fileType switch
        {
            FileType.Csv => new CsvFileHandler<TUnit>(),
            FileType.Json => new JsonFileHandler<TUnit>(),
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

    public List<TUnit> ImportUnits<TUnit>() => GetFileType<TUnit>().ReadUnits<TUnit>(GetFilePath());
    public void ExportUnits<TUnit>(List<TUnit> units) => GetFileType<TUnit>().WriteUnits(units, GetFilePath());
}
