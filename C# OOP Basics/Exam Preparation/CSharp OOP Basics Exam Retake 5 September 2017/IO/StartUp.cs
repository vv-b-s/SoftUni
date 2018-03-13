using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());

        var raceTower = new RaceTower();
        raceTower.SetTrackInfo(numberOfLaps, trackLength);

        while(raceTower.CurrentLap<raceTower.LapsNumber)
        {
            try
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                var arguments = input.Skip(1).ToList();

                switch (command)
                {
                    case "RegisterDriver": raceTower.RegisterDriver(arguments); break;

                    case "Leaderboard": Console.WriteLine(raceTower.GetLeaderboard()); break;

                    case "CompleteLaps": 
                        var result = raceTower.CompleteLaps(arguments);
                        if (!string.IsNullOrWhiteSpace(result))
                            Console.WriteLine(result);
                        break;

                    case "Box": raceTower.DriverBoxes(arguments); break;

                    case "ChangeWeather": raceTower.ChangeWeather(arguments); break;
                }
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
        }

        var winner = raceTower.Winner;
        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.");
    }
}