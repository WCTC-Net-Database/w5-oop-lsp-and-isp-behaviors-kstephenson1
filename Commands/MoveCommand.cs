using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class MoveCommand : ICommand
{
    // The MoveCommand takes in a unit and a position, checks to see if the unit can move, then moves to that position of able.

    private readonly IEntity _unit;
    private readonly Position _position;
    public MoveCommand(IEntity unit, Position position)
    {
        _unit = unit;
        _position = position;
    }
    public void Execute()
    {
        if (_unit is IEntity)
        {
            _unit.Position = _position;
            Console.WriteLine($"{_unit.Name} moves to {_position.ToString()}");
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot move!");
        }
        
    }
}
