using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.FileIO.Csv;
using w5_assignment_ksteph.Interfaces;
using w5_assignment_ksteph.Inventories;

namespace w5_assignment_ksteph.Entities;

public abstract class Unit : IEntity, IAttackable, IAttack, IInventory
{
    [Name("Name")]                                          // CsvHelper Attribute
    public virtual required string Name { get; set; }

    [Name("Class")]                                         // CsvHelper Attribute
    public virtual required string Class { get; set; }

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
    public virtual Position Position { get; set; } = new();

    public Unit() { }

    public Unit(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
    }

    public virtual void Attack(IEntity target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");
    }

    public virtual void Move(Position position)
    {
        Console.WriteLine($"{Name} moves to {position.ToString}");
    }

    public virtual void TakeDamage(int damage)
    {
        HitPoints -= damage;
        OnDamageTaken();

        if (IsDead())
            OnDeath();
    }

    public virtual void OnDamageTaken()
    {

    }

    public virtual void OnDeath()
    {

    }

    public bool IsDead()
    {
        return HitPoints <= 0 ? true : false;
    }

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{HitPoints},{Inventory}";
    }

}
