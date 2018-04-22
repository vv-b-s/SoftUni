using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var machineType = Arguments[0];

        if (machineType == "Harvester")
            return this.HarvesterController.Register(Arguments.Skip(1).ToList());

        else if (machineType == "Provider")
            return this.ProviderController.Register(Arguments.Skip(1).ToList());

        else return null;
    }
}