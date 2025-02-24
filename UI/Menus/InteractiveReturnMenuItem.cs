using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.UI;
public class InteractiveReturnMenuItem<Ttype> : InteractiveMenuItem
{
    // The MainMenuItem is used to store information about the selection in the main menu.  This stores the index and name (from the base),
    // description, and an acion in a handy object that can be referenced easily later.
    public Ttype Selection { get; set; }

    public InteractiveReturnMenuItem(int index, string name, string desc, Ttype selection): base(index, name, desc)
    {
        Index = index;
        Name = name;
        Description = desc;
        Selection = selection;
    }
}
