using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w5_assignment_ksteph.Characters;
using w5_assignment_ksteph.UI;

namespace w5_assignment_ksteph;

public class GameEngine
{
    public void StartGameEngine()
    {
        Initialization();
        Run();
        End();
    }

    public static void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        UserInterface.BuildMenus(); // Builds the menus and prepares the user interface tables.
        CharacterManager.ImportCharacters(); //Imports the caracters from the csv or json file.
    }

    public static void Run()
    {
        UserInterface.InteractiveMainMenu.RunInteractiveMenu();
    }

    public static void End()
    {
        // Exports the character list back to the chosen file format and ends the program.

        CharacterManager.ExportCharacters(); //Outputs the characters into the chosen file format.
        //UserInterface.ExitMenu.Show(true); //Shows the exit menu and leaves the program.
    }
}
