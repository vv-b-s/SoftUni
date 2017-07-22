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
        var pattern = new Regex(@"(?<city>[A-Z]{2})(?<avgTemp>\d+\.\d+)(?<weatherType>[a-zA-Z]+)(?=\|)");

        var text = new StringBuilder();
        string input;
        while((input=ReadLine())!="end")
            text.AppendLine(input);

        var weathers = new List<Weather>();
        var matches = pattern.Matches(text.ToString());

        foreach(Match match in matches)
        {
            var city = match.Groups["city"].Value;
            var temp = match.Groups["avgTemp"].Value;
            var weather = match.Groups["weatherType"].Value;

            bool noWeatherUpgraded = true;
            for (int i = 0; i < weathers.Count; i++)
                if (weathers[i].City == city)
                {
                    weathers[i] = new Weather(city, temp, weather);
                    noWeatherUpgraded = false;
                }

            if (noWeatherUpgraded)
                weathers.Add(new Weather(city, temp, weather));
        }

        weathers = weathers.OrderBy(w => w.AverageTemp).ToList();
        foreach (var weather in weathers)
            WriteLine(weather);
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