namespace w5_assignment_ksteph.FileIO;

public interface ICharacterIO
{
    List<TUnit> ReadUnits<TUnit>(string dir);
    void WriteUnits<TUnit>(List<TUnit> units, string dir);
}
