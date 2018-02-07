using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var regionsMeteors = new Dictionary<string, Region>();

        var input = "";
        while((input=ReadLine())!="Count em all")
        {
            var data = Regex.Split(input, " -> ");

            var region = data[0];
            var meteorType = data[1];
            var numberOfMeteors = long.Parse(data[2]);

            if (!regionsMeteors.ContainsKey(region))
                regionsMeteors[region] = new Region();

            switch(meteorType)
            {
                case "Black": regionsMeteors[region].BlackMeteors += numberOfMeteors; break;
                case "Green": regionsMeteors[region].AddGreenMeteors(numberOfMeteors); break;
                case "Red": regionsMeteors[region].AddRedMeteors(numberOfMeteors); break;
            }
        }

        regionsMeteors = regionsMeteors
            .OrderByDescending(r => r.Value.BlackMeteors)
            .ThenBy(r => r.Key.Length)
            .ThenBy(r => r.Key)
            .ToDictionary(k => k.Key, v => v.Value);

        var output = new StringBuilder();
        var meteorTypes = new Dictionary<string, long>();
        foreach (var region in regionsMeteors)
        {
            output.AppendLine(region.Key);

            meteorTypes["Black"] = region.Value.BlackMeteors;
            meteorTypes["Green"] = region.Value.GreenMeteors;
            meteorTypes["Red"] = region.Value.RedMeteors;

            var sortedMeteors = meteorTypes.OrderByDescending(m => m.Value).ThenBy(m=>m.Key);
            foreach (var meteor in sortedMeteors)
                output.AppendLine($"-> {meteor.Key} : {meteor.Value}");

            meteorTypes.Clear();
        }

        Write(output);
    }
}

class Region
{
    private long _greenMeteors;
    private long _redMeteors;

    public long GreenMeteors => _greenMeteors;
    public long RedMeteors => _redMeteors;
    public long BlackMeteors { get; set; }


    public void AddGreenMeteors(long amount)
    {
        //if the new value added to the green meteors exceeds 1 000 000, increment the red meteors by one and increment the green by the left meteors
        if (amount + _greenMeteors >= 1_000_000)
        {
            var totalMeteors = _greenMeteors + amount;
            var numberOfMeteorsToAdd = totalMeteors / 1_000_000;
            AddRedMeteors(numberOfMeteorsToAdd);

            _greenMeteors = totalMeteors % 1_000_000;
        }
        else _greenMeteors += amount;
    }

    public void AddRedMeteors(long amount)
    {
        //if the new value added to the red meteors exceeds 1 000 000, increment the black meteors by one and increment the red by the left meteors
        if (amount + _redMeteors >= 1_000_000)
        {
            var totalMeteors = _redMeteors + amount;
            var numberOfMeteorsToAdd = totalMeteors / 1_000_000;
            BlackMeteors += numberOfMeteorsToAdd;


            _redMeteors = totalMeteors % 1_000_000;
        }
        else _redMeteors += amount;
    }

    public Region()
    {
        _greenMeteors = 0;
        _redMeteors = 0;
    }
}

