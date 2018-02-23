using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Team>();

            var input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var data = input.Split(';');

                    var command = data[0];
                    var teamName = data[1];

                    if (command == "Team")
                        teams[data[1]] = new Team(name: data[1]);

                    else if (command == "Rating")
                    {
                        ValidateTeam(teams, teamName);
                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }

                    else if (command == "Add")
                    {
                        ValidateTeam(teams, teamName);

                        var player = new Player(
                            name: data[2],
                            endurance: ValidateStats(data[3], "Endurance"),
                            sprint: ValidateStats(data[4], "Sprint"),
                            dribble: ValidateStats(data[5], "Dribble"),
                            passing: ValidateStats(data[6], "Passing"),
                            shooting: ValidateStats(data[7], "Shooting"));

                        teams[teamName].AddPlayer(player);

                    }

                    else if (command == "Remove")
                    {
                        ValidateTeam(teams, teamName);
                        teams[teamName].RemovePlayer(playerName: data[2]);
                    }
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }
        }

        private static void ValidateTeam(Dictionary<string, Team> teams, string teamName)
        {
            if (!teams.ContainsKey(teamName))
                throw new ArgumentException($"Team {teamName} does not exist.");
        }

        private static double ValidateStats(string value, string statName)
        {
            if (double.TryParse(value, out double stat))
                return stat;
            throw new ArgumentException($"{statName} should be between 0 and 100.");
        }
    }
}
