using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;


class Vehicle
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }

    public Vehicle(string type,string model, string color, int horsepower)
    {
        Type = type=="car"? 
            type.Replace('c','C'):
            type.Replace('t','T');

        Model = model;
        Color = color;
        Horsepower = horsepower;
    }
}

class Program
{
    static void Main()
    {
        var vehicles = new Dictionary<string, List<Vehicle>>()
        {
            {"truck",new List<Vehicle>() },
            {"car", new List<Vehicle>() }
        };

        string input;
        while((input=ReadLine())!="End")
        {
            var temp = input.Split();
            string type = temp[0].ToLower();
            string model = temp[1];
            string color = temp[2];
            int hp = int.Parse(temp[3]);

            vehicles[type].Add(new Vehicle(type, model, color, hp));
        }

        while ((input = ReadLine()) != "Close the Catalogue")
        {
            Vehicle vehicle = FindVehicle(input, vehicles);

            WriteLine($"Type: {vehicle.Type}\n" +
                $"Model: {vehicle.Model}\n" +
                $"Color: {vehicle.Color}\n" +
                $"Horsepower: {vehicle.Horsepower}");
        }

        WriteLine($"Cars have average horsepower of: {(vehicles["car"].Count>0? vehicles["car"].Average(v => v.Horsepower):0):f2}.");
        WriteLine($"Trucks have average horsepower of: {(vehicles["truck"].Count>0? vehicles["truck"].Average(v => v.Horsepower):0):f2}.");
    }

    private static Vehicle FindVehicle(string model, Dictionary<string, List<Vehicle>> vehicles)
    {
        foreach (var vList in vehicles.Values)
            foreach (var vehicle in vList)
                if (vehicle.Model == model)
                    return vehicle;
        return null;
    }
}