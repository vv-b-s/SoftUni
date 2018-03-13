using System;
using System.Collections.Generic;
using System.Text;

public static class TyreFactory
{
    public static Tyre CreateTyre(Queue<string> arguments)
    {
        var tyreType = arguments.Dequeue() + "Tyre";
        var tyreHardness = double.Parse(arguments.Dequeue());

        Tyre tyreInstance;
        if (tyreType == "UltrasoftTyre")
        {
            var grip = double.Parse(arguments.Dequeue());

            tyreInstance = Activator.CreateInstance(Type.GetType(tyreType), tyreHardness, grip) as Tyre;
        }

        else tyreInstance = Activator.CreateInstance(Type.GetType(tyreType), tyreHardness) as Tyre;

        return tyreInstance ?? throw new ArgumentException();
    }
}