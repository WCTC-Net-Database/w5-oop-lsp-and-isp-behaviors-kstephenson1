﻿namespace w5_assignment_ksteph.UI;
public class InteractiveMainMenuItem : InteractiveMenuItem
{
    // The MainMenuItem is used to store information about the selection in the main menu.  This stores the index and name (from the base),
    // description, and an acion in a handy object that can be referenced easily later.
    public Action Action { get; set; }

    public InteractiveMainMenuItem(int index, string name, string desc, Action action): base(index, name, desc)
    {
        Index = index;
        Name = name;
        Description = desc;
        Action = action;
    }
}
