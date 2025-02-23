namespace w5_assignment_ksteph.FileIO;

using w5_assignment_ksteph.FileIO.Csv;
using w5_assignment_ksteph.FileIO.Json;
using w5_assignment_ksteph.Config;
using w5_assignment_ksteph.DataTypes;
using w5_assignment_ksteph.Entities.Characters;

public class FileManager
{

    private static FileType _fileType = Config.DEFAULT_FILE_TYPE;

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

    // FileManager contains redirects to functions that assist with Csv functions. 
    public List<Character> ImportCharacters() => GetFileType().ReadCharacters();
    public void ExportCharacters(List<Character> characters) => GetFileType().WriteCharacters(characters);
}
