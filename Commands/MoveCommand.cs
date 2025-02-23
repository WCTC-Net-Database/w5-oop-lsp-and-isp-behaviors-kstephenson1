using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class MoveCommand : ICommand
{
    private readonly IEntity _unit;
    private readonly Position _position;
    public MoveCommand(IEntity unit, Position position)
    {
        _unit = unit;
        _position = position;
    }
    public void Execute()
    {
        _unit.Position = _position;
        Console.WriteLine($"{_unit.Name} moves to {_position.ToString()}");
    }
}
