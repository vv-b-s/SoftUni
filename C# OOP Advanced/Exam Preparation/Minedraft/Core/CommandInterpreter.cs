using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        var command = args[0];
        var commandType = Type.GetType(command + "Command");

        var commandInstance = Activator.CreateInstance(commandType, args.Skip(1).ToList(), HarvesterController, ProviderController) as ICommand;

        var commandResult = commandInstance.Execute();

        return commandResult;
    }
}
