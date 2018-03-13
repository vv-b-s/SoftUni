using System;
using System.Collections.Generic;
using System.Text;

public static class DriverFactory
{
    public static Driver CreateDriver(Queue<string> arguments)
    {

        var driverType = arguments.Dequeue() + "Driver";
        var driverName = arguments.Dequeue();

        var car = CreateCar(arguments);

        var driverInstance = Activator.CreateInstance(Type.GetType(driverType), driverName, car) as Driver;

        return driverInstance ?? throw new ArgumentException();
    }

    public static Car CreateCar(Queue<string> arguments)
    {
        var horsePower = int.Parse(arguments.Dequeue());
        var fuelAmount = double.Parse(arguments.Dequeue());

        var tyre = TyreFactory.CreateTyre(arguments);

        var carInstance = Activator.CreateInstance(typeof(Car), horsePower, fuelAmount, tyre) as Car;

        return carInstance ?? throw new ArgumentException();
    }
}