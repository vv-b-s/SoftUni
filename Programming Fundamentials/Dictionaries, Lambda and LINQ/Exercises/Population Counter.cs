using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

public class Country:IComparable<Country>
{
    public Dictionary<string, long> CityPopulation = new Dictionary<string, long>();

    public long CountryPopulation => CityPopulation.Values.Sum();

    void OrderCitiesByPopulation() => CityPopulation = CityPopulation.OrderByDescending(c => c.Value).ToDictionary(c => c.Key, s => s.Value);

    public string ListCities()
    {
        OrderCitiesByPopulation();
        var output = new StringBuilder();

        foreach (var city in CityPopulation)
            output.AppendLine($"=>{city.Key}: {city.Value}");
        return output.ToString();
    }

    public int CompareTo(Country other)
    {
        if (CountryPopulation > other.CountryPopulation)
            return 1;
        if (CountryPopulation < other.CountryPopulation)
            return -1;
        else
            return 0;
    }
}

class Program
{
    static void Main()
    {
        var CountryData = new Dictionary<string, Country>();

        string entry;
        while ((entry = ReadLine()) != "report")
        {
            var city = entry.Split('|')[0];
            var country = entry.Split('|')[1];
            var population = long.Parse(entry.Split('|')[2]);

            if(CountryData.Keys.Contains(country))
                CountryData[country].CityPopulation[city] = population;
            else
            {
                CountryData[country] = new Country();
                CountryData[country].CityPopulation[city] = population;
            }
        }

        CountryData = CountryData.OrderByDescending(c => c.Value.CountryPopulation).ToDictionary(c =>c.Key,s=>s.Value);

        foreach (var country in CountryData)
            Write($"{country.Key} (total population: {country.Value.CountryPopulation})\n" +
                $"{country.Value.ListCities()}");
        

    }
}