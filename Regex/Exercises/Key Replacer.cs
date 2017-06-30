using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Weather
{
    public string City { set; get; }
    public double AverageTemp { set; get; }
    public string WeatherType { set; get; }

    public Weather(string city, string avgTemp, string weatherType)
    {
        City = city;
        AverageTemp = double.Parse(avgTemp);
        WeatherType = weatherType;
    }

    public override string ToString() => $"{City} => {AverageTemp:f2} => {WeatherType}";    
}

class Program
{
    static void Main()
    {
        var key = ReadLine();
        var startKey = Regex.Match(key, @"^[^\|\<\\]+").Value;
        var endKey = Regex.Match(key, @"[^\|\\\<]+$").Value;

        var text = ReadLine();
        var matches = Regex.Matches(text, $@"(?<=({startKey}))(?!{endKey}).+?(?!{startKey})(?=({endKey}))")
            .Cast<Match>()
            .Select(m => m.Value)
            .ToArray();

        WriteLine(matches.Length>0?
            string.Join("", matches):
            "Empty result");
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