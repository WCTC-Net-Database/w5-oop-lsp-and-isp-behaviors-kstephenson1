*Author's Note:  I was having a little too much fun.  I've never really had the oppertunity to use generics and did not understand the extent of how useful they were.  Now that i've had the opportunity to expand on my file i/o methods to include generic types, I can now say I understand why they are so great, and am a huge fan.  I've never used interfaces before, neither.  It's incredible how much flexibility and control interfaces give while manipulating all sorts of alike classes.  I went a little overboard with this assignment, and I have learned quite a lot while completing it.  I am proud of my work, I hope you enjoy.*

## ConsoleRPG Feature Notes v0.1.5

### New Interactive Menu
We are happy to introduce the new interactive menu!  Instead of prompting the user for a number, we have a new menu that allows the user to hit up, down, and enter to make selections.

### New Interfaces
- IAttack - Allows a unit to attack.
- IAttackable - Allows a unit to be attacked.
- ICastable - Allows a unit to cast spells.
- IEntity - Allows a unit to exist.
- IFlyable - Allows a unit to fly.
- IHeal - Allows a unit to heal.
- IInventory - Allows a unit to hold items.
- IShootable - Allows a unit to shoot
- ICommand - An interface to implement the new command system.
- ...and a few others.

### New Classes
Introducing new unit structure system that includes:
- Abstract Unit class that implements IEntity that serves as a base for other units.
   - Generic Monster class
      - An Archer class that is able to shoot.
      - A Cleric class that can heal others and cast spells.
      - A Ghost class that can fly.
      - A Goblin class with no special features.
      - A Mage class that can cast spells.
   - Generic Character class
      - A Cleric class that can heal others and cast spells.
      - A Fighter class that attack.
      - A Knight class that can attack.
      - A Rogue class that can attack.
      - A Wizard class that can cast spells.

### Refactors For Generic Types!
A few changes have been made to a few classes to allow for generic types to be used.
- Character importing and exporting
   - UnitManager<TUnit> - now allows generic types to allow importing of other types of units instead of just characters.  A new monsters.csv and monsters.json file have been added that load monsters into the game.
   - FileManager<T>, CsvFileHandler<T>, and JsonFileHandler<T> - now allows generic types to allow importing and exporting of other types of objects instead of just units.  Does work with items such as weapons, but is not implemented yet.
- InteractiveReturnMenu
   - InteractiveReturnMenu<TType> is a menu that allows the user to select an option using the new interactive menu and returns a generic type.  This new menu type is being used to:
      - Ask the user to select a unit and returns a unit.
      - Asks the user to select a command and returns an ICommand.
      - Used in the Interactive Main Menu to store Actions.
- Unit storage
   - A new UnitSet<TUnit> class allows storage of sets of units of a certain type.  We currently implement two unit sets:
      - UnitSet<Character> that holds a list of characters
      - UnitSet<Monster> that holds a list of monsters of various classes.

### Custom Items
- Custom items that are compatible with json/csv import/export.
  - WeaponItem - An item you can equip that holds weapon stats such as durability, damage, hit and crit strike chance, among others.  This item can have many instances.
    - Includes dagger, mace, staff, and sword.
    - *Note: Weapon stats have not been implemented yet.*
  - ConsumableItem
    - PotionItem - An item with 3 uses that heals the user for 10hp.
    - BookItem - It's a book.
    - LockpickItem - Unlocks doors, traps, and chests.
      - *Note: doors, traps, and chests have not been implemented yet.*

### New Command System
A new command system has been added that implements the usage of ICommand.
- Unit Commands
  - AttackCommand - Allows a unit to attack another unit.  The attack command uses a hit chance and a crit chance to determine whether or not an attack lands.  Damage is also calculated.
  - CastCommand - Allows a unit to cast a spell.  Takes in a spell name and causes the unit to cast the named spell.
  - FlyCommand - Allows a unit to fly.  A unit will fly instead of move when move is called.
  - HealCommand - Allows a unit to heal others.  Takes in a target and calculates crit chance and heal amount.  Heal spells cannot miss.
  - MoveCommand - Allows a unit to move.  Asks the user for an x-coord and a z-coord and moves the unit to that position.
  - ShootCommand - Allows a unit to shoot another unit.  The attack command uses a hit chance and a crit chance to determine whether or not an attack lands.  Damage is also calculated.  A unit will shoot instead of attack if possible.
  - Item Commands
    - UseItemCommand - Allows the unit to use a consumable item.
    - EquipItemCommand - Allows the unit to equip a weapon item.
    - DropItemCommand - Allows the unit to drop an item.
    - TradeItemCommand - Allows the unit to trade any item with another unit.
 
### Game Engine
Last, but certainly not least, we have implemented a new GameEngine class.
- Shows the main menu that allows:
   - Display Characters
      - Displays each character, their basic information, and their inventory.
   - Find Character
      - Prompts the user for a character name and displays character information for that character.
   - New Character
      - Asks the user for some information and creates a new character.
   - Level Up Character
      - Asks the user for a character name and levels that character up by one.
   - Change File Format
      - Switches the file format between .csv and .json
   - Start Game
     -UI Includes a display that shows units' hit points.
      - Asks the user to select a unit from the new interactive menu.
      - Asks the user to select an action using the new interactive menu.
         - Move:
            - Asks the user to input an x-coord and a z-coord
            - Flies the unit if it is able to.
            - Moves the unit if it is able to.
        - Items:
            - Asks the user to select an item in the unit's inventory.
            - Checks for the commands that the item can use, then asks to choose from those commands.
            - executes the selected command.
         - Attack:
            - Asks the user to select a target unit.
            - Shoots the target unit if it is able to do so.
            - Attacks the target unit if it is able to.
               - Calculates hit and crit chance.  (Crit deals double damage)
               - Applies damage if applicable.
         - Heal:
            - Asks the user to select a unit to heal.
            - Heals if the unit is able to.
         - Cast:
            - Asks the user for a spell name.
            - The unit casts that spell if it is able to.




## Week 5 Assignment: Refactor ConsoleRPG to Adhere to LSP and Implement New Behaviors

### Objective

The goal of this assignment is to refactor the existing `ConsoleRPG` program to follow the Liskov Substitution Principle (LSP) and apply the Interface Segregation Principle (ISP) by creating new, focused interfaces and implementing additional behaviors. You will:

1. Remove the `Fly()` method from `IEntity` and create an appropriate behavior class to handle this functionality.
2. Implement at least two new classes with their own unique behaviors (following ISP).
3. Integrate these new behaviors into the `GameEngine`.

### Instructions

#### Part 1: Refactor `IEntity` to Fix LSP Violation

1. **Remove `Fly()` from `IEntity`**: The current design violates the Liskov Substitution Principle because not all entities can fly.
2. **Create `IFlyable` Interface**:
   - Define an `IFlyable` interface that includes the `Fly()` method.
   - Update the `Ghost` class to implement `IFlyable`.
   - Use a delegate or behavior class to encapsulate the `Fly()` functionality.
3. **Update `GameEngine`**:
   - Modify `GameEngine` to use the new `IFlyable` interface correctly, checking if an entity can fly before calling `Fly()`.

#### Part 2: Create Additional Classes and Behaviors

1. **Design Two New Classes**:
   - Create at least two new classes that extend `IEntity` and implement unique behaviors.
   - You are free to design any behaviors or classes you like. Some examples include:
     - **Archer** with an `IShootable` interface that defines a `Shoot()` method.
     - **Mage** with an `ICastable` interface that defines a `CastSpell(string spellName)` method.
   - Use the **Interface Segregation Principle (ISP)** to design small, focused interfaces for these new behaviors.

2. **Implement the New Behaviors**:
   - Implement these behaviors in the new classes you create.
   - Ensure each behavior is appropriately encapsulated and extendable.

3. **Integrate with `GameEngine`**:
   - Update the `GameEngine` to support the new behaviors.
   - Ensure the `GameEngine` can interact with entities dynamically using these new behaviors.

#### Examples of New Behaviors

- **IShootable**:
  - Interface: `public interface IShootable { void Shoot(); }`
  - Implementation in `Archer`: Defines `Shoot()` to allow the archer to attack with a bow.
- **ICastable**:
  - Interface: `public interface ICastable { void CastSpell(string spellName); }`
  - Implementation in `Mage`: Defines `CastSpell(string spellName)` to allow the mage to perform magic.

#### Part 3: Testing and Demonstration

1. **Test Your Code**: 
   - Make sure your new behaviors work correctly with the `GameEngine`.
   - Test the existing `Character`, `Ghost`, and your new classes to ensure they adhere to the Liskov Substitution Principle.

2. **Demonstrate**:
   - Run the `GameEngine` with different entities to demonstrate the new behaviors in action.
   - Show how the `GameEngine` can interact with the entities using their respective interfaces.

### Stretch Goals

1. **Implement the Command Pattern**:
   - Enhance your code by implementing a simplified **Command Pattern** for one or more behaviors.
   - **Explanation**:
     - The Command Pattern encapsulates a request as an object, allowing you to parameterize clients with queues, logs, or undoable operations.
     - To simplify this:
       1. **Create a Command Interface**: Define a single interface, such as `ICommand`, with a method `Execute()`.
       2. **Implement Concrete Command Classes**: Create classes like `FlyCommand` or `AttackCommand` that implement `ICommand` and encapsulate the logic for each action.
       3. **Modify the Game Engine**: Adjust the `GameEngine` to hold a list of commands and execute them sequentially.
   - **Benefits**:
     - This approach enables you to encapsulate behaviors as commands, providing flexibility to execute, queue, or log actions in the game engine.

### Submission

- **Code Submission**:
  - Refactor the existing code and add your new classes in the provided project.
  - Ensure your project builds and runs successfully.
- **Documentation**:
  - Update the README file to include a brief description of each new behavior and how they are used in the game.
- **GitHub**:
  - Push your changes to the GitHub Classroom repository.

### Rubric (100 Points Total)

| Criteria                                  | Points |
|-------------------------------------------|--------|
| **Refactoring for LSP**                   |        |
| - Correctly removed `Fly()` from `IEntity` and created an `IFlyable` interface. | 20     |
| - Updated `GameEngine` to use the new `IFlyable` interface. | 10     |
| **Implementing New Behaviors**            |        |
| - Created at least two new classes with unique behaviors. | 20     |
| - Designed and implemented small, focused interfaces for each new behavior. | 10     |
| - Integrated new behaviors into `GameEngine` without violating LSP. | 10     |
| **Integration and Testing**               |        |
| - Successfully integrated new behaviors into the game logic. | 10     |
| - Demonstrated that the program runs and behaves as expected. | 10     |
| **Code Quality and Documentation**        |        |
| - Code is clean, well-documented, and follows best practices. | 10     |
| **Stretch Goal: Implement Command Pattern** |        |
| - Successfully implemented a simplified Command Pattern for one or more behaviors. | +10    |

Here are some resource links to help students better understand the concepts covered in the assignment:

### Resources
- [Interfaces in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/) - Official Microsoft documentation on using interfaces in C#.
- [Type Casting in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions) - A guide to casting and type conversions in C#.

#### SOLID Principles
- [SOLID Principles: A Guide for Developers](https://www.freecodecamp.org/news/solid-principles-every-developer-should-know/) - A detailed guide covering all the SOLID principles with examples.
- [Liskov Substitution Principle Explained](https://stackify.com/solid-design-liskov-substitution-principle/) - An easy-to-understand explanation of LSP with examples.
- [LSP in C#](https://www.tutorialsteacher.com/csharp/liskov-substitution-principle) - A tutorial focused on implementing LSP in C#.
- [Interface Segregation Principle (ISP)](https://www.baeldung.com/cs/interface-segregation-principle) - A guide to understanding and implementing ISP.
- [Interface Segregation in C#](https://www.tutorialsteacher.com/csharp/interface-segregation-principle) - A detailed tutorial with examples in C#.

#### Stretch Goal: Command Pattern
- [Command Design Pattern in C#](https://refactoring.guru/design-patterns/command/csharp/example) - A comprehensive guide on implementing the Command Pattern in C#.
- [The Command Pattern Explained](https://www.dofactory.com/net/command-design-pattern) - An overview of the Command Pattern with examples in .NET.
