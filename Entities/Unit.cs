using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w5_assignment_ksteph.Combat;
using w5_assignment_ksteph.Commands.Invokers;
using w5_assignment_ksteph.Commands.UnitCommands;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.FileIO.Csv.Converters;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Interfaces.CharacterBehaviors;
using w5_assignment_ksteph.Interfaces.InventoryBehaviors;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities;

public abstract class Unit : IEntity, IAttackable, IAttack, IHaveInventory
{
    // Unit is an abstract class that holds basic unit properties and functions.

    [Name("Name")]                                          // CsvHelper Attribute
    public virtual string Name { get; set; }

    [Name("Class")]                                         // CsvHelper Attribute
    public virtual string Class { get; set; }

    [Name("Level")]                                         // CsvHelper Attribute
    public virtual int Level { get; set; }

    [Name("HP")]                                            // CsvHelper Attribute
    [JsonPropertyName("HP")]                                // Json Atribute
    public virtual int HitPoints { get; set; }

    [Ignore]
    public virtual int MaxHitPoints { get; set; }

    [Name("Equipment")]                                     // CsvHelper Attribute
    [JsonPropertyName("Equipment")]                         // Json Atribute
    [TypeConverter(typeof(CsvInventoryConverter))]          // CsvHelper Attribute that helps CsvHelper import a new inventory object instead of a string.
    public virtual Inventory Inventory { get; set; } = new();

    [Name("Position")]                                         // CsvHelper Attribute
    [JsonPropertyName("Position")]                         // Json Atribute
    [TypeConverter(typeof(CsvPositionConverter))]          // CsvHelper Attribute that helps CsvHelper import a new Position struct instead of a string.
    public virtual Position Position { get; set; } = new();

    [Ignore]
    [JsonIgnore]
    public virtual CommandInvoker Invoker { get; set; } = new();

    [Ignore]
    [JsonIgnore]
    public virtual AttackCommand AttackCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public virtual MoveCommand MoveCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public UnitStats Stats { get; set; } = null!;

    public Unit() { }

    public Unit(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
    }

    // Attacks the target unit.
    public virtual void Attack(IEntity target)
    {
        AttackCommand = new(this, target);
        Invoker.ExecuteCommand(AttackCommand);
    }

    // Moves the unit to a position.
    public virtual void Move(Position position)
    {
        MoveCommand = new(this, position);
        Invoker.ExecuteCommand(MoveCommand);
    }

    // Has the unit take damage then check if it is dead.
    public virtual void TakeDamage(int damage)
    {
        HitPoints -= damage;
        OnDamageTaken();

        if (IsDead())
            OnDeath();
    }

    // Triggers every time this unit takes damage.
    public virtual void OnDamageTaken()
    {
        if (HitPoints > MaxHitPoints)
            HitPoints = MaxHitPoints;
        if (HitPoints <= 0)
            HitPoints = 0;
    }

    // Triggers when this unit dies.
    public virtual void OnDeath()
    {
        
    }

    // Function to check to see if unit should be dead.
    public bool IsDead()
    {
        return HitPoints <= 0 ? true : false;
    }

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{HitPoints},{Inventory}";
    }

    public string GetHealthBar()
    {
        string bar = "[[";
        for (int i = 0; i < MaxHitPoints; i++)
        {
            if (i < HitPoints)
                bar += "[green]■[/]";
            else
                bar += "[red3]■[/]";
        }
        bar += "]]";

        if (HitPoints <= 0)
        {
            return $"[dim]{bar}[/]";
        }
        return bar;
    }

}
