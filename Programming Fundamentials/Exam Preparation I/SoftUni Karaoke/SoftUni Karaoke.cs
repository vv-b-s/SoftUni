using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Participant
{
    public string Name { set; get; }
    public List<string> Awards { set; get; }

    public Participant(string name)
    {
        Name = name;
        Awards = new List<string>();
    }

    public void AddAward(string name)
    {
        if (Awards.Contains(name))
            return;
        Awards.Add(name);
    }
}

class Program
{
    static void Main()
    {
        var participants = Regex.Split(ReadLine(), ", ").Where(p => p != "").Select(p => new Participant(p)).ToDictionary(k => k.Name, v => v);
        var songs = Regex.Split(ReadLine(), ", ").Where(s => s != "").ToList();

        string input;
        while((input=ReadLine())!="dawn")
        {
            var rawData = Regex.Split(input, ", ");
            string participant = rawData[0];
            string song = rawData[1];
            string award = rawData[2];

            if(participants.ContainsKey(participant))
            {
                if (songs.Contains(song))
                    participants[participant].AddAward(award);
            }
        }

        if (participants.Any(p => p.Value.Awards.Count > 0))
        {
            participants = participants
                .Where(p => p.Value.Awards.Count > 0)
                .OrderByDescending(p => p.Value.Awards.Count)
                .ThenBy(p => p.Value.Name)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var participant in participants)
            {
                participant.Value.Awards = participant.Value.Awards.OrderBy(a => a).ToList();

                WriteLine($"{participant.Key}: {participant.Value.Awards.Count} awards");
                Write(PrintAwards(participant.Value.Awards));
            }
        }
        else
            WriteLine("No awards");

    }

    private static string PrintAwards(List<string> awards)
    {
        var sB = new StringBuilder();
        foreach (var award in awards)
            sB.AppendLine($"--{award}");
        return sB.ToString();
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