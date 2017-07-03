using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Driver
{
    public string Name { get; }
    public decimal Fuel { set; get; }
    public long LastReachedZone { set; get; }
    public bool DriverFinished { set; get; }

    public Driver(string name)
    {
        Name = name;
        Fuel = name[0];
    }

    public void AddFuel(decimal value, long zoneIndex)
    {
        Fuel += value;
        LastReachedZone = zoneIndex;
        DriverFinished = Fuel > 0;
    }

    public void SubstractFuel(decimal value, long zoneIndex)
    {
        Fuel -= value;
        LastReachedZone = zoneIndex;
        DriverFinished = Fuel > 0;
    }
}

class Program
{
    static void Main()
    {
        var drivers = Regex.Split(ReadLine(), @"\s").Where(d => d != "").Select(d => new Driver(d)).ToList();
        var zoneValues = Regex.Split(ReadLine(), @"\s").Where(zV => zV != "").Select(decimal.Parse).ToList();
        var CheckPoints = Regex.Split(ReadLine(), @"\s").Where(i => i != "").Select(long.Parse).ToList();

        foreach (var driver in drivers)
        {
            for (int i = 0; i < zoneValues.Count; i++)
            {
                if (CheckPoints.Contains(i))
                {
                    driver.AddFuel(zoneValues[i], i);
                    if (!driver.DriverFinished)
                        break;
                }
                else
                {
                    driver.SubstractFuel(zoneValues[i], i);
                    if (!driver.DriverFinished)
                        break;
                }
            }

            WriteLine(driver.DriverFinished ?
                $"{driver.Name} - fuel left {driver.Fuel:f2}" :
                $"{driver.Name} - reached {driver.LastReachedZone}");
        }
    }

    static string AddVar(string value)
    {
        var sB = new StringBuilder();
        sB.Append('{');
        sB.Append(value);
        sB.Append('}');
        return sB.ToString();
    }

}