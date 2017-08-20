using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static Dictionary<string, Dictionary<string, long>> Trains = new Dictionary<string, Dictionary<string, long>>();
    static void Main()
    {
        string input;

        while((input=ReadLine())!= "It's Training Men!")
        {
            char[] splitChars = new char[] { '-', '>', ':', '=', ' ' };
            string[] data = input.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
            if (input.Contains(":"))
                AddWagons(data);
            else if (input.Contains("="))
                CopyWagons(data); 
            else
                MoveWagonsToATrain(data);
        }

        Trains = Trains
            .OrderByDescending(t => t.Value.Sum(w=>w.Value))
            .ThenBy(t => t.Value.Count)
            .ToDictionary(k => k.Key, v => v.Value);

        foreach(var train in Trains)
        {
            var wagons = train.Value.OrderByDescending(w => w.Value).ToList();
            WriteLine($"Train: {train.Key}");
            foreach (var wagon in wagons)
                WriteLine($"###{wagon.Key} - {wagon.Value}");
        }
    }

    private static void CopyWagons(string[] data)
    {
        string train1 = data[0];
        string train2 = data[1];

        if (!Trains.ContainsKey(train1))
            Trains[train1] = new Dictionary<string, long>();

        Trains[train1].Clear();

        foreach (var wagon in Trains[train2])
            Trains[train1].Add(wagon.Key, wagon.Value);
    }

    private static void MoveWagonsToATrain(string[] data)
    {
        string train1 = data[0];
        string train2 = data[1];

        if(!Trains.ContainsKey(train1))
            Trains[train1] = new Dictionary<string, long>();

        foreach (var wagon in Trains[train2])
            Trains[train1].Add(wagon.Key, wagon.Value);

        Trains.Remove(train2);
    }

    private static void AddWagons(string[] data)
    {
        string trainName = data[0];
        string wagonName = data[1];
        int wagonPower = int.Parse(data[2]);

        if (Trains.ContainsKey(trainName))
            Trains[trainName].Add(wagonName,wagonPower);
        else
            Trains[trainName] = new Dictionary<string, long> { { wagonName, wagonPower } };
    }
}
