using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Gamer
{
    private static Dictionary<string, int> CardPoints = new Dictionary<string, int>
    {
        {"2",2 },
        {"3",3 },
        { "4",4},
        { "5",5},
        { "6",6},
        { "7",7},
        { "8",8},
        { "9",9},
        { "10",10},
        { "J",11},
        { "Q",12},
        { "K",13},
        { "A",14}
    };

    private static Dictionary<char, int> Multiplyer = new Dictionary<char, int>
    {
        { 'S',4 },
        { 'H',3},
        { 'D',2},
        { 'C',1}
    };

    private List<string> hand = new List<string>();

    public List<string> Hand
    {
        set
        {
            foreach (var item in value)
                hand.Add(item);
        }
        get { return hand; }
    }
    public int Scores => CalculateScores();
    
    int CalculateScores()
    {
        var scores = 0;

        var distinctedHand = hand.Distinct().ToList();

        foreach(var value in distinctedHand)
            scores += CardPoints[value.Length < 3 ? $"{value[0]}" : $"{value[0]}{value[1]}"] * Multiplyer[value.Last()];
        return scores;
    }
    
}

class Program
{
    static void Main()
    {
        string userInput;

        var NameGamer = new Dictionary<string, Gamer>();

        while((userInput=ReadLine())!="JOKER")
        {
            string name = userInput.Split(':')[0];

            if (!NameGamer.Keys.Contains(name))
                NameGamer[name] = new Gamer();

            NameGamer[name].Hand = userInput.Split(':')[1]
                    .Split(',',' ')
                    .Where(c => c != "")
                    .ToList();
        }

        foreach (var gamer in NameGamer)
            WriteLine($"{gamer.Key}: {gamer.Value.Scores}");
    }
}