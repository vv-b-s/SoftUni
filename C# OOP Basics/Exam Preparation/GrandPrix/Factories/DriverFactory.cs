using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    public static Driver CreateDriver(List<string> args)
    {
        var type = Type.GetType(args[0] + "Driver");
        var name = args[1];
        var carHp = int.Parse(args[2]);
        var carFuelAmount = double.Parse(args[3]);

        var tyre = TyreFactory.CreateTyre(args.Skip(4).ToList());
        var car = new Car(carHp, carFuelAmount, tyre);

        var driver = Activator.CreateInstance(type, name, car) as Driver;

        return driver;
    }
}