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
        var teamWorms = new Dictionary<string, Dictionary<string, long>>();
        var teamNames = new List<string>();

        string input;
        while((input=ReadLine())!="quit")
        {
            var match = Regex.Match(input, @"(?<wormName>[\w\s]+)\s->\s(?<teamName>[\w\s]+)\s->\s(?<wormScore>\d+)").Groups;
            var wormName = match["wormName"].Value;
            var teamName = match["teamName"].Value;
            var wormScore = long.Parse(match["wormScore"].Value);

            if(!teamWorms.Values.Any(v=>v.ContainsKey(wormName)))
            {
                if (teamWorms.ContainsKey(teamName))
                    teamWorms[teamName][wormName] = wormScore;
                else
                {
                    teamWorms[teamName] = new Dictionary<string, long> { { wormName, wormScore } };
                    teamNames.Add(teamName);
                }
            }
        }

        foreach(var team in teamNames)
            teamWorms[team] = teamWorms[team].OrderByDescending(w => w.Value).ToDictionary(k => k.Key, v => v.Value);

        teamWorms = teamWorms.OrderByDescending(t => t.Value.Values.Sum()).ThenByDescending(t => t.Value.Values.Average()).ToDictionary(k => k.Key, v => v.Value);

        var teamCount = 0;
        foreach(var team in teamWorms)
        {
            teamCount++;
            WriteLine($"{teamCount}. Team: {team.Key} - {team.Value.Values.Sum()}");
            foreach (var worm in team.Value)
                WriteLine($"###{worm.Key} : {worm.Value}");
        }
    }
}
