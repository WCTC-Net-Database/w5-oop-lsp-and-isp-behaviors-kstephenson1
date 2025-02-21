namespace w4_assignment_ksteph.UI;
public class MainMenuItem : MenuItem
{
    // The MainMenuItem is used to store information about the selection in the main menu.  This stores the index and name (from the base),
    // description, and an acion in a handy object that can be referenced easily later.
    public string Description { get; set; }
    public Action Action { get; set; }

    public MainMenuItem(int index, string name, string desc, Action action): base(index, name)
    {
        Index = index;
        Name = name;
        Description = desc;
        Action = action;
    }
}
