using w5_assignment_ksteph.DataTypes.Structs;
using w5_assignment_ksteph.Interfaces;

namespace w5_assignment_ksteph.Commands;

public class FlyCommand : ICommand
{
    // FlyCommand takes in a unit and a position, checks to see if the unit is able to fly, then flies to the position if able.

    private readonly IEntity _unit;
    private readonly Position _position;
    public FlyCommand(IEntity unit, Position position)
    {
        _unit = unit;
        _position = position;
    }
    public void Execute()
    {
        if (_unit is IFlyable)
        {
            _unit.Position = _position;
            Console.WriteLine($"{_unit.Name} flies to {_position.ToString()}");
        } else
        {
            Console.WriteLine($"{_unit.Name} cannot fly and remains on {_unit.Position}");
        }
    }
}
