using System;
using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre CreateTyre(List<string> args)
    {
        var type = Type.GetType(args[0]+"Tyre");
        var hardness = double.Parse(args[1]);

        Tyre tyre;
        if(args.Count>2)
        {
            var grip = double.Parse(args[2]);
            tyre = Activator.CreateInstance(type,hardness,grip) as Tyre;
        }

        else tyre = Activator.CreateInstance(type,hardness) as Tyre;

        return tyre;
    }
}