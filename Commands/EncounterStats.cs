using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class EncounterStats
{
    private static Random _generator = new Random();
    int Roll;
    public IEntity Unit { get; set; }
    public IEntity Target { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int HitChance { get; set; }
    public int CritChance { get; set; }

    public EncounterStats(IEntity unit, IEntity target, int minDamage, int maxDamage, int hitChance, int critChance)
    {
        Roll = _generator.Next(100) + 1;
        Unit = unit;
        Target = target;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        HitChance = hitChance;
        CritChance = critChance;
    }


    public int RollDamage()
    {
        if (IsCrit())
        {
            return CalculateDamage() + CalculateDamage();
        }
        else if (IsHit())
        {
            return CalculateDamage();
        }
        return 0;
    }

    private int CalculateDamage()
    {
        return _generator.Next(MinDamage, MaxDamage + 1);
    }

    public bool IsCrit()
    {
        return Roll > MathF.Abs(CritChance - 100) ? true : false;
    }

    public bool IsHit()
    {
        return Roll > MathF.Abs(HitChance - 100) ? true : false;
    }

}
