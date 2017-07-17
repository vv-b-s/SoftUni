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
        var takeOffTime = ReadLine().Split(':');
        var time = new Dictionary<string, long>
        {
            {"hours",long.Parse(takeOffTime[0]) },
            { "minutes", long.Parse(takeOffTime[1])},
            { "seconds",long.Parse(takeOffTime[2])}
        };

        var stepsToTake = long.Parse(ReadLine());
        var timeToAdd = long.Parse(ReadLine()) * stepsToTake;

        var hoursToAdd = timeToAdd / 3600;
        time["hours"] += hoursToAdd;
        timeToAdd -= hoursToAdd * 3600;

        var minutesToAdd = timeToAdd / 60;
        time["minutes"] += minutesToAdd;
        timeToAdd -= minutesToAdd * 60;

        time["seconds"] += timeToAdd;

        FormatTimeCorrectly(time);

        WriteLine($"Time Arrival: {time["hours"]:d2}:{time["minutes"]:d2}:{time["seconds"]:d2}");
    }

    private static void FormatTimeCorrectly(Dictionary<string, long> time)
    {
        if(time["seconds"] >59)
        {
            time["seconds"] %= 60;
            time["minutes"]++;
        }
        if(time["minutes"]>59)
        {
            time["minutes"] %= 60;
            time["hours"]++;
        }
        time["hours"] %= 24;
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