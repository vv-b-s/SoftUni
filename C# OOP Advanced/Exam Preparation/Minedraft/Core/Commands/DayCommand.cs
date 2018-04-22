using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var energyProducedMessage = ProviderController.Produce();
        var oresGainedMessage = HarvesterController.Produce();

        return $"{energyProducedMessage}{Environment.NewLine}{oresGainedMessage}";
    }
}
