using w5_assignment_ksteph.Entities.Characters;

namespace w5_assignment_ksteph.FileIO;

public interface ICharacterIO
{
    List<Character> ReadCharacters();
    void WriteCharacters(List<Character> characters);
}
