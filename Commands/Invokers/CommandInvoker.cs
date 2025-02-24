namespace w5_assignment_ksteph.Commands.Invokers;

public class CommandInvoker
{
    private List<ICommand> _commands;

    public CommandInvoker()
    {
        _commands = new();
    }

    public void ExecuteCommand(ICommand command)
    {
        _commands.Add(command);
        command.Execute();
    }
}
