using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var output = $"System Shutdown{Environment.NewLine}Total Energy Produced: {ProviderController.TotalEnergyProduced}{Environment.NewLine}Total Mined Plumbus Ore: {HarvesterController.OreProduced}";
        return output;
    }
}