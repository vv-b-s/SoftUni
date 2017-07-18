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
        var teamScores = new Dictionary<string, List<int>>();
        var key = InputFormatedForRegex(ReadLine());

        var pattern = new Regex($@"{key}(\w+){key}");
        string input;
        while((input=ReadLine())!="final")
        {
            var temp = Regex.Split(input, @"\s+").Where(i => i != "").ToArray();


            var teams = new string[] { pattern.Match(temp[0]).Groups[1].Value, pattern.Match(temp[1]).Groups[1].Value };

            var scores = new int[] { int.Parse(temp[2].Split(':')[0]), int.Parse(temp[2].Split(':')[1]) };

            teams[0] = new string(teams[0].Reverse().ToArray()).ToUpper();
            teams[1] = new string(teams[1].Reverse().ToArray()).ToUpper();

            
            foreach(var team in teams)
            {
                if (!teamScores.ContainsKey(team))
                    teamScores[team] = new List<int> { 0,0 };

                if (scores[0] == scores[1])
                {
                    teamScores[team][0]++;
                    teamScores[team][1] += scores[0];
                }
            }

            if (scores[0] > scores[1])
            {
                teamScores[teams[0]][0] += 3;
                teamScores[teams[0]][1] += scores[0];
                teamScores[teams[1]][1] += scores[1];
            }
            if(scores[0]<scores[1])
            {
                teamScores[teams[1]][0] += 3;
                teamScores[teams[1]][1] += scores[1];
                teamScores[teams[0]][1] += scores[0];
            }
        }

        teamScores = teamScores.OrderByDescending(t => t.Value[0]).ThenBy(n => n.Key).ToDictionary(k => k.Key, v => v.Value);

        WriteLine("League standings:");
        var teamcounter = 1;
        foreach(var team in teamScores)
        {
            WriteLine($"{teamcounter}. {team.Key} {team.Value[0]}");
            teamcounter++;
        }

        WriteLine("Top 3 scored goals:");
        var topThree = teamScores.OrderByDescending(t => t.Value[1]).ThenBy(n => n.Key).Take(3).ToDictionary(k => k.Key, v => v.Value);
        foreach(var team in topThree)
            WriteLine($"- {team.Key} -> {team.Value[1]}");

    }

    private static string InputFormatedForRegex(string input)
    {
        var sB = new StringBuilder();
        foreach (var ch in input)
            sB.Append(char.IsSymbol(ch)||char.IsSeparator(ch)||char.IsPunctuation(ch) ?
                $@"\{ch}" :
                $"{ch}");
        return sB.ToString();
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