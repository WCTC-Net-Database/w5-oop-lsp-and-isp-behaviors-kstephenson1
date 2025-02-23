using System.Numerics;

namespace w5_assignment_ksteph.DataTypes.Structs;

public struct Position
{
    public int x;
    public int z;

    public Position(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position position &&
            x == position.x &&
            z == position.z;
    }

    public bool Equals(Position position)
    {
        return this == position;
    }

    public static bool operator == (Position a, Position b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator != (Position a, Position b)
    {
        return !(a == b);
    }

    public static Position operator + (Position a, Position b)
    {
        return new Position(a.x + b.x, a.z + b.z);
    }

    public static Position operator - (Position a, Position b)
    {
        return new Position(a.x - b.x, a.z - b.z);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public override string ToString()
    {
        return $"[{x}, {z}]";
    }
}
