using System;
using System.Collections.Generic;
using System.Text;

public class ProviderFactory
{
    public static Provider GetProvider(IList<string> args)
    {
        try
        {
            Provider provider = null;

            var type = Type.GetType(args[0] + "Provider");

            var id = args[1];
            var energyOutput = double.Parse(args[2]);

            provider = Activator.CreateInstance(type, id, energyOutput) as Provider;

            return provider;
        }
        catch (System.Reflection.TargetInvocationException e)
        {
            throw e.InnerException;
        }
    }
}