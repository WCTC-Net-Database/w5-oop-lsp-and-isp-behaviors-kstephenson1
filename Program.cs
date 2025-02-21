
using w4_assignment_ksteph.DataHelper;
using w4_assignment_ksteph.Characters;
using w4_assignment_ksteph.UI;

namespace w4_assignment_ksteph;

class Program
{
    static void Main()
    {
        Initialization();
        //Test();
        Run();
        End();
    }

    public static void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        UserInterface.BuildMenus(); // Builds the menus and prepares the user interface tables.
        CharacterManager.ImportCharacters(); //Imports the caracters from the csv file.
    }

    public static void Run()
    {
        while (true) // Will run until exit is selected
        {
            UserInterface.MainMenu.Show(); //Shows the main menu.

            // Uses a helper file to get an int between 1-{UserInterface.MainMenu.Count()} from the user.
            int selection = Input.GetInt(1, UserInterface.MainMenu.Count(), $"Value must be between 1-{UserInterface.MainMenu.Count()}"); 

            if (selection == UserInterface.MainMenu.Count()) break; // Exits the program if 'End' is selected.
            UserInterface.MainMenu.Action(selection); // Runs the action of the selected main menu item.
        }
    }

    public static void End()
    {
        // Exports the character list back to the chosen file format and ends the program.

        CharacterManager.ExportCharacters(); //Outputs the characters into the chosen file format.
        UserInterface.ExitMenu.Show(true); //Shows the exit menu and leaves the program.
    }

    //public static void Test() // for testing purposes only.
    //{
       
    //}

}
