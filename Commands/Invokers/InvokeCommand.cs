namespace w5_assignment_ksteph.Commands.Invokers;

public class InvokeCommand
{
    private List<ICommand> _commands;
    private ICommand _command;

    public InvokeCommand()
    {
        _commands = new();
    }

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _commands.Add(_command);
        _command.Execute();
    }

    public void ExecuteCommand(ICommand command)
    {
        _commands.Add(command);
        command.Execute();
    }
}
