namespace w5_assignment_ksteph.UI;
public class InteractiveReturnMenuItem<Ttype> : InteractiveMenuItem
{
    // The InteractiveReturnMenuItem is used to store information about the selection in the main menu.  This stores the index and name (from the base),
    // description, and a generic type.
    public Ttype Selection { get; set; }

    public InteractiveReturnMenuItem(int index, string name, string desc, Ttype selection): base(index, name, desc)
    {
        Index = index;
        Name = name;
        Description = desc;
        Selection = selection;
    }
}
