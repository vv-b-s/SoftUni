using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        var input = "";
        var pattern = new Regex(@"(?<commandType>[A-Za-z]+)\((?<commandArgs>.*)\)");
        var interpreter = new Interpreter();

        while((input = Console.ReadLine())!="System Split")
        {
            var match = pattern.Match(input);
            var command = match.Groups["commandType"].Value;
            var arguments = GetArgs(match.Groups["commandArgs"].Value);

            switch(command)
            {
                case "RegisterPowerHardware":
                    interpreter.RegisterHardware<PowerHardware>(arguments[0], int.Parse(arguments[1]), int.Parse(arguments[2]));
                    break;

                case "RegisterHeavyHardware":
                    interpreter.RegisterHardware<HeavyHardware>(arguments[0], int.Parse(arguments[1]), int.Parse(arguments[2]));
                    break;

                case "RegisterExpressSoftware":
                    interpreter.RegisterSoftware<ExpressSoftware>(arguments[0], arguments[1], int.Parse(arguments[2]), int.Parse(arguments[3]));
                    break;

                case "RegisterLightSoftware":
                    interpreter.RegisterSoftware<LightSoftware>(arguments[0], arguments[1], int.Parse(arguments[2]), int.Parse(arguments[3]));
                    break;

                case "ReleaseSoftwareComponent":
                    interpreter.ReleaseSoftwareComponent(arguments[0], arguments[1]);
                    break;

                case "Analyze":
                    Console.WriteLine(interpreter.Analyze());
                    break;

                case "Dump":
                    interpreter.Dump(arguments[0]);
                    break;

                case "Restore":
                    interpreter.Restore(arguments[0]);
                    break;

                case "Destroy":
                    interpreter.Destroy(arguments[0]);
                    break;

                case "DumpAnalyze":
                    Console.WriteLine(interpreter.DumpAnalyze());
                    break;
            }
        }

        Console.Write(interpreter.SystemSplit());
    }

    private static string[] GetArgs(string input) => Regex.Split(input, ", ");
}