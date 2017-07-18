using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var distance = double.Parse(ReadLine());
        var fuelTankCap = double.Parse(ReadLine());
        var milesSpentPerHeavyWinds = double.Parse(ReadLine());

        distance -= milesSpentPerHeavyWinds;

        var neededFuel = (distance * 25 + milesSpentPerHeavyWinds * (25 * 1.5))*1.05;

        WriteLine($"Fuel needed: {neededFuel:f2}L");
        WriteLine(fuelTankCap >= neededFuel ?
            $"Enough with {fuelTankCap - neededFuel:f2}L to spare!" :
            $"We need {neededFuel - fuelTankCap:f2}L more fuel.");
    }
}
