namespace w5_assignment_ksteph.FileIO;

using w5_assignment_ksteph.FileIO.Csv;
using w5_assignment_ksteph.FileIO.Json;
using w5_assignment_ksteph.Config;
using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.Entities.Characters;
using w5_assignment_ksteph.Entities.Monsters;

public class FileManager<TUnit>
{
    Type _unitType = typeof(TUnit);
    private static FileType _fileType = Config.DEFAULT_FILE_TYPE;
    Dictionary<Type, int> _unitTypeDict = new Dictionary<Type, int>
        {
            {typeof(Character),0},
            {typeof(Monster),1},
        };

    public string GetFilePath()
    {
        return _unitTypeDict[_unitType] switch
        {
            0 => "Files/characters",
            1 => "Files/monsters",
            _ => throw new ArgumentOutOfRangeException($"GetFilePath() has invalid type ({_unitTypeDict})")
        };

    }

    private static ICharacterIO GetFileType() // Checks to see what the current file type is set to and execute the proper file system.
    {
        return _fileType switch
        {
            FileType.Csv => new CsvFileHandler(),
            FileType.Json => new JsonFileHandler(),
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

    // FileManager contains redirects to functions that assist with file IO functions.
    //public List<Character> ImportCharacters() => GetFileType().ReadCharacters();
    //public void ExportCharacters(List<Character> characters) => GetFileType().WriteCharacters(characters);
    public List<TUnit> ImportUnits() => GetFileType().ReadUnits<TUnit>(GetFilePath());
    public void ExportUnits(List<TUnit> units) => GetFileType().WriteUnits<TUnit>(units, GetFilePath());
}
