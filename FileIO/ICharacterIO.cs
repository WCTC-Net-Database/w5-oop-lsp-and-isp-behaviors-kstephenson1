using w4_assignment_ksteph.Characters;

namespace w4_assignment_ksteph.FileIO;

public interface ICharacterIO
{
    List<Character> ReadCharacters();
    void WriteCharacters(List<Character> characters);
}
