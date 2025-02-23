using w5_assignment_ksteph.Entities.Characters;

namespace w5_assignment_ksteph.FileIO;

public interface ICharacterIO
{
    //List<Character> ReadCharacters();
    //void WriteCharacters(List<Character> characters);
    List<TUnit> ReadUnits<TUnit>(string dir);
    void WriteUnits<TUnit>(List<TUnit> units, string dir);
}
