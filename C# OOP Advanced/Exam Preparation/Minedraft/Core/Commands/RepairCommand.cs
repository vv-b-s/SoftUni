using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        if(Arguments.Count==2)
        {
            var repairId = Arguments[0];
            var repairValue = int.Parse(Arguments[1]);

            var provider = (ProviderController as ProviderController).Entities.First(e => e.ID == int.Parse(repairId)) as IProvider;
            provider.Repair(repairValue);

            return string.Format(Constants.ProvidersRepaired, repairValue);
        }

        else
        {
            var repairValue = double.Parse(Arguments[0]);

            var repairResult = this.ProviderController.Repair(repairValue);

            return repairResult;
        }
    }
}