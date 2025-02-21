﻿namespace w4_assignment_ksteph.Characters;

using Spectre.Console;
using w4_assignment_ksteph.Config;
using w4_assignment_ksteph.DataHelper;
using w4_assignment_ksteph.Inventories;
public class CharacterFunctions
{
    // CharacterFunctions class contains fuctions that manipulate characters based on user input.
    public static void NewCharacter() // Creates a new character.  Asks for name, class, level, hitpoints, and items.
    {
        string name = Input.GetString("Enter your character's name: ");
        string characterClass = Input.GetString("Enter your character's class: ");
        int level = Input.GetInt("Enter your character's level: ", 1, Config.CHARACTER_LEVEL_MAX, $"character level must be 1-{Config.CHARACTER_LEVEL_MAX}");
        int hitPoints = Input.GetInt("Enter your character's maximum hit points: ", 1, "must be greater than 0");
        Inventory inventory = new();

        while (true)
        {
            string? newItem = Input.GetString($"Enter the name of an item in {name}'s inventory. (Leave blank to end): ", false);
            if (newItem != "")
            {
                inventory.Items!.Add(new(newItem));
                continue;
            }
            break;
        }

        Console.Clear();
        Console.WriteLine($"\nWelcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", inventory)}.\n");

        CharacterManager.AddCharacter(
            new() { Name = name, Class = characterClass, Level = level, HitPoints = hitPoints, Inventory = inventory });

        CharacterManager.ExportCharacters();
    }

    public static void FindCharacter() // Asks the user for a name and displays a character based on input.
    {
        string characterName = Input.GetString("What is the name of the character you would like to search for? ");
        Character character = FindCharacterByName(characterName)!;
        Console.Clear();

        if (character != null)
        {
            character.DisplayCharacterInfo();
        }
        else
        {
            AnsiConsole.MarkupLine($"[Red]No characters found with the name {characterName}\n[/]");
        }
    }

    private static Character? FindCharacterByName(string name) // Finds and returns a character based on input.
    {
        return CharacterManager.Characters.Where(character => String.Equals(character.Name, name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
    }

    public static void LevelUp() //Asks the user for a character to level up, then displays that character.
    {
        string characterName = Input.GetString("What is the name of the character that you would like to level up? ");
        Character character = FindCharacterByName(characterName)!;
        Console.Clear();

        if (character != null)
        {
            if (character.Level < Config.CHARACTER_LEVEL_MAX)
            {
                character.Level++;
                AnsiConsole.MarkupLine($"[Green]Congratulations! {character.Name} has reached level {character.Level}[/]\n");
                character.DisplayCharacterInfo();
            }
            else
            {
                AnsiConsole.MarkupLine($"[Red]{character.Name} is already max level! ({Config.CHARACTER_LEVEL_MAX})[/]\n");
            }
        }
        else
        {
            AnsiConsole.MarkupLine($"[Red]No characters found with the name {characterName}[/]\n");
        }
    }
}
