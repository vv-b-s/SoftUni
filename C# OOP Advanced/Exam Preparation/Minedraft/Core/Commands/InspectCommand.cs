using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var entityFound = true;
        IEntity entity = null;

        if (int.TryParse(Arguments[0], out int id))
        {
            var allEntities = (this.HarvesterController as HarvesterController).Entities.Concat((this.ProviderController as ProviderController).Entities);

            entity = allEntities.FirstOrDefault(e => e.ID == id);

            if (entity is null)
                entityFound = false;
        }
        else entityFound = false;


        return entityFound ? entity.ToString() : string.Format(Constants.EntityNotFound, Arguments[0]);        
    }
}