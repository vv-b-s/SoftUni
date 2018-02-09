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
        var teamsWins = new Dictionary<string, int>();
        var teamOponents = new Dictionary<string, HashSet<string>>();

        string input;
        while ((input = ReadLine())!="stop")
        {
            var inputData = Regex.Split(input, @" \| ");

            var team1 = inputData[0];
            var team2 = inputData[1];

            if (!teamsWins.ContainsKey(team1))
            {
                teamsWins[team1] = 0;
                teamOponents[team1] = new HashSet<string>();
            }

            if (!teamsWins.ContainsKey(team2))
            {
                teamsWins[team2] = 0;
                teamOponents[team2] = new HashSet<string>();
            }

            teamOponents[team1].Add(team2);
            teamOponents[team2].Add(team1);

            var scoresOnTeamOneSoil = inputData[2].Split(':').Select(int.Parse).ToArray();
            var scoresOnTeamTwoSoil = inputData[3].Split(':').Select(int.Parse).ToArray();

            var teamOneScores = scoresOnTeamOneSoil[0] + scoresOnTeamTwoSoil[1];
            var teamTwoScores = scoresOnTeamOneSoil[1] + scoresOnTeamTwoSoil[0];

            if (teamOneScores > teamTwoScores)
                teamsWins[team1]++;
            else if (teamTwoScores > teamOneScores)
                teamsWins[team2]++;
            else if(teamTwoScores==teamOneScores)
            {
                if (scoresOnTeamTwoSoil[1] > scoresOnTeamOneSoil[1])
                    teamsWins[team1]++;
                else if (scoresOnTeamTwoSoil[1] < scoresOnTeamOneSoil[1]) 
                    teamsWins[team2]++;
            }
        }

        teamsWins = teamsWins.OrderByDescending(t => t.Value).ThenBy(t => t.Key).ToDictionary(k => k.Key, v => v.Value);
        
        foreach(var team in teamsWins)
        {
            WriteLine(team.Key);
            WriteLine($"- Wins: {team.Value}");
            WriteLine($"- Opponents: {string.Join(", ", teamOponents[team.Key].OrderBy(to => to))}");
        }
    }
}