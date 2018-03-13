using System;
using System.Collections.Generic;
using System.Text;

public class HarvesterFactory
{
    public static Harvester GetHarvester(IList<string> args)
    {
        try
        {
            Harvester harvester = null;

            var type = Type.GetType(args[0] + "Harvester");

            var id = args[1];
            var oreOutput = double.Parse(args[2]);
            var energyRequirement = double.Parse(args[3]);

            if (type == typeof(SonicHarvester))
            {
                var sonicFactor = int.Parse(args[4]);
                harvester = Activator.CreateInstance(type, id, oreOutput, energyRequirement, sonicFactor) as Harvester;
            }
            else
                harvester = Activator.CreateInstance(type, id, oreOutput, energyRequirement) as Harvester;

            return harvester;
        }
        catch (System.Reflection.TargetInvocationException e)
        {
            throw e.InnerException;
        }
    }
}