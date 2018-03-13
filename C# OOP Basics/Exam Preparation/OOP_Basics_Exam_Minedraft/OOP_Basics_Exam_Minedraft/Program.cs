using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = "";
        var dm = new DraftManager();

        while((input = Console.ReadLine())!="Shutdown")
        {
            var args = input.Split();
            var command = args[0];

            var arguments = args.Skip(1).ToList();

            switch(command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(dm.RegisterHarvester(arguments));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(dm.RegisterProvider(arguments));
                    break;

                case "Day":
                    Console.WriteLine(dm.Day());
                    break;

                case "Mode":
                    Console.WriteLine(dm.Mode(arguments));
                    break;

                case "Check":
                    Console.WriteLine(dm.Check(arguments));
                    break;
            }
        }

        Console.WriteLine(dm.ShutDown());
    }
}