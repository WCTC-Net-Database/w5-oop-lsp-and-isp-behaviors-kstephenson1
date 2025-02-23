namespace w5_assignment_ksteph.Entities.Characters;

using w5_assignment_ksteph.FileIO;


// The CharacterHandler class contains methods that manipulate Characters data, including displaying, adding, and leveling up characters.

public class UnitCollection<TUnit>
{


    public virtual List<TUnit> Units { get; set; } = new(); // A list of characters objects for reference

    public void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        Units = new FileManager<TUnit>().ImportUnits();
    }

    public void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        new FileManager<TUnit>().ExportUnits(Units);
    }

    public void AddUnit(TUnit unit)            // Adds a new character to the stored characters list.
    {
        Units.Add(unit);
    }

    public void DeleteUnit(TUnit unit)         // Removes a character from the stored characters list.
    {
        Units.Remove(unit);
    }
}
