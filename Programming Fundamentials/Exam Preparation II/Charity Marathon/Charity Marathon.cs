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
        var days = int.Parse(ReadLine());
        var numberOfRunners = long.Parse(ReadLine());
        var avgNumberOfLaps = int.Parse(ReadLine());
        var trackLen = long.Parse(ReadLine());
        var trackCap = int.Parse(ReadLine());
        var moneyPerKM = decimal.Parse(ReadLine());

        numberOfRunners = trackCap * days >= numberOfRunners ? numberOfRunners : trackCap * days;

        var totalMeters = numberOfRunners * avgNumberOfLaps * trackLen;
        var totalKM = totalMeters / 1000m;
        var moneyRaised = decimal.Round(totalKM * moneyPerKM,2);

        WriteLine($"Money raised: {moneyRaised:f2}");
    }
}