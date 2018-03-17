using System;
using System.Linq;

public class MainClass
{
    public static void Main(string[] args)
    {
        var rt = new RaceTower();
        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());

        rt.SetTrackInfo(numberOfLaps, trackLength);

        while (rt.CurrentLap < numberOfLaps) 
        {
            var input = Console.ReadLine().Split();
            var command = input[0];
            var arguments = input.Skip(1).ToList();

            switch(command)
            {
                case "RegisterDriver":
                    rt.RegisterDriver(arguments);
                    break;

                case "Leaderboard":
                    Console.WriteLine(rt.GetLeaderboard());
                    break;

                case "CompleteLaps":
                    var result = rt.CompleteLaps(arguments);
                    if(result.Length>0)
                        Console.WriteLine(result);
                    break;

                case "Box":
                    rt.DriverBoxes(arguments);
                    break;

                case "ChangeWeather":
                    rt.ChangeWeather(arguments);
                    break;
            }
        }

        var winner = rt.Winner;
        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.");
    }
}