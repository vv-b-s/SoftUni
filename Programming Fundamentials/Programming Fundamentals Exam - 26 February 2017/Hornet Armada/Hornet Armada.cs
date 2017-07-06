using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Legion
{
    public Dictionary<string, long> SoldierTypeCount { set; get; }

    public long Activity { set; get; }
    public long SoldierCount => SoldierTypeCount.Values.Sum();

    public Legion(string soldierType, long soldiers, long activity)
    {
        SoldierTypeCount = new Dictionary<string, long>();
        AddSoldiers(soldierType, soldiers, activity);
    }

    public void AddSoldiers(string soldierType, long soldiers, long activity)
    {
        if (SoldierTypeCount.ContainsKey(soldierType))
            SoldierTypeCount[soldierType] += soldiers;
        else
            SoldierTypeCount[soldierType] = soldiers;

        Activity = activity > Activity ? activity : Activity;
    }
}


class Program
{
    static void Main()
    {

        var pattern = new Regex(@"^(?<activity>\d+)\s+=\s+(?<legionName>[^=->:\s]+)\s+->\s+(?<soldierType>[^=->:\s]+)\s*:\s*(?<soldierCount>\d+)$");
        var Legions = new Dictionary<string, Legion>();

        for (int i = int.Parse(ReadLine()); i > 0; i--)
        {
            var input = ReadLine();
            if (pattern.IsMatch(input))
            {
                var matches = pattern.Match(input);
                var activity = long.Parse(matches.Groups["activity"].Value);
                var legionName = matches.Groups["legionName"].Value;
                var soldierType = matches.Groups["soldierType"].Value;
                var soldierCount = long.Parse(matches.Groups["soldierCount"].Value);

                if (Legions.ContainsKey(legionName))
                    Legions[legionName].AddSoldiers(soldierType, soldierCount, activity);
                else
                    Legions[legionName] = new Legion(soldierType, soldierCount, activity);
            }
        }

        var command = ReadLine();
        if (command.Contains("\\"))
        {
            long activity = long.Parse(command.Split('\\')[0]);
            string soldierType = command.Split('\\')[1];

            if (Legions.Any(l => l.Value.SoldierTypeCount.ContainsKey(soldierType)))
            {
                var querryResult = Legions
                        .Where(l => l.Value.Activity < activity&&l.Value.SoldierTypeCount.ContainsKey(soldierType))
                        .OrderByDescending(s => s.Value.SoldierTypeCount[soldierType])
                        .ToDictionary(k => k.Key, v => v.Value);

                foreach (var legion in querryResult)
                    WriteLine($"{legion.Key} -> {legion.Value.SoldierTypeCount[soldierType]}");
            }
        }
        else
        {
            var querryResult = Legions
                .Where(l => l.Value.SoldierTypeCount.ContainsKey(command))
                .OrderByDescending(l => l.Value.Activity)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var legion in querryResult)
                WriteLine($"{legion.Value.Activity} : {legion.Key}");
        }
    }
}
