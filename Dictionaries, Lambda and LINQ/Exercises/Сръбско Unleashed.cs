using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var SingerLog = new Dictionary<string, Dictionary<string, long>>();

        string input;        
        while((input=ReadLine())!="End")
        {
            if(InputIsCorrect(input))
            {
                string   name          = new string (input.TakeWhile(i => i != '@').ToArray()).Trim();                                                              // Takes input from 0 to '@' and removes useless spaces
                string   place         = new string (input.SkipWhile(i => i != '@').TakeWhile(i => i == '@' || (i < '0' || i > '9')).ToArray()).Trim('@', ' ');    // Takes input from '@' to the first met digit and removes any useless spaces and '@'
                string[] priceTickets  = new string (input.SkipWhile(i => i < '0' || i > '9').ToArray()).Split();                                                 // Takes numeric input and splits it into array
                int      ticketPrice   = int .Parse (priceTickets[0]);
                long     boughtTickets = long.Parse (priceTickets[1]);

                if (name == ""||place==""||name.Split().Length>3||place.Split().Length>3)
                    continue;

                if (SingerLog.ContainsKey(place))
                {
                    if (SingerLog[place].ContainsKey(name))
                        SingerLog[place][name] += ticketPrice * boughtTickets;
                    else
                        SingerLog[place][name] = ticketPrice * boughtTickets;
                }
                else
                {
                    SingerLog[place] = new Dictionary<string, long>();
                    SingerLog[place][name] = ticketPrice * boughtTickets;
                }
                
            }
        }


        var filteredLog = new Dictionary<string, Dictionary<string, long>>();
        foreach (var log in SingerLog)
        {
            filteredLog[log.Key] = SingerLog[log.Key].OrderByDescending(s => s.Value)
                .ToDictionary(k => k.Key, v => v.Value);
        }

        foreach(var place in filteredLog)
        {
            Write($"{place.Key}\n" +
                $"{DisplaySingerAndSalery(filteredLog,place.Key)}");
        }

    }

    static string DisplaySingerAndSalery(Dictionary<string, Dictionary<string,long>> SingerLog, string place)
    {
        var output = new StringBuilder();

        foreach (var singer in SingerLog[place])
            output.AppendLine($"#  {singer.Key} -> {singer.Value}");
        return output.ToString();
    }

    static bool InputIsCorrect(string input)
    {
        input = input.ToLower();
        if (!input.Contains("@"))
            return false;
        for(int i=0;i<input.Length;i++)
        {
            if (input[i] == '@' && (input[i-1] != ' '||input[i+1]==' '))                                  // Checks if '@' is separated with a ' ' on the left
                return false;
            if (input[i] >= '0' && input[i] <= '9' && input[i - 1] >= 'a' && input[i - 1] <= 'z')      // Makes sure that numeric input is surrounded only with numbers and ' ' and no letters are near
                return false;
            if ((input[i] < '0' || input[i] > '9') && (input[i] < 'a' || input[i] > 'z') && input[i] != ' ' && input[i] != '@')
                return false;
        }
        return true;
    }
}