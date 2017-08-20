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
        int numberOfParticipants = int.Parse(ReadLine());
        var teamMoneyEarned = new Dictionary<string, double>();

        double[] teams = new double[3];


        for (int i = 0; i < numberOfParticipants; i++)
        {
            int distanceInMeters = int.Parse(ReadLine()) * 1600;
            double cargoWeight = double.Parse(ReadLine()) * 1000;
            string teamName = ReadLine();

            double littersFuelConsumed = distanceInMeters * 0.7;

            double participantEarnedMoney = (cargoWeight * 1.5) - (littersFuelConsumed * 2.5);

            switch(teamName)
            {
                case "Technical":
                    teams[0] += participantEarnedMoney;
                    break;
                case "Theoretical":
                    teams[1] += participantEarnedMoney;
                    break;
                case "Practical":
                    teams[2] += participantEarnedMoney;
                    break;
            }
        }

        var winningTeamMoney = teams.Max();

        string winningteamName="";
        if (winningTeamMoney == teams[0])
            winningteamName = "Technical";
        else if (winningTeamMoney == teams[1])
            winningteamName = "Theoretical";
        else
            winningteamName = "Practical";

        WriteLine($"The {winningteamName} Trainers win with ${winningTeamMoney:f3}.");
    }
}
