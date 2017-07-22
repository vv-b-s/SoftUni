using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Team
{
    public string Leader { set; get; }
    public string TeamName { set; get; }
    public List<string> Members;

    public Team(string leader, string teamName)
    {
        Leader = leader;
        TeamName = teamName;

        Members = new List<string>();
    }

    public void AddMember(string memberName) => Members.Add(memberName);
}

class Program
{
    static void Main()
    {
        var teams = new List<Team>();
        for(int i = int.Parse(ReadLine());i>0;i--)
        {
            string[] input = ReadLine().Split('-');
            string leaderName = input[0];
            string teamName = input[1];

            if(teams.Any(t=>t.TeamName==teamName))
            {
                WriteLine($"Team {teamName} was already created!");
                continue;
            }

            if(teams.Any(l => l.Leader == leaderName))
            {
                WriteLine($"{leaderName} cannot create another team!");
                continue;
            }

            teams.Add(new Team(leaderName, teamName));
            WriteLine($"Team {teamName} has been created by {leaderName}!");
        }

        while(true)
        {
            string input = ReadLine();
            if (input == "end of assignment")
                break;

            string[] temp = input.Split('-','>').Where(i=>i!="").ToArray();
            string memberName = temp[0];
            string teamName = temp[1];

            if(!teams.Any(t=>t.TeamName==teamName))
            {
                WriteLine($"Team {teamName} does not exist!");
                continue;
            }
            if (teams.Any(m => m.Members.Contains(memberName)) || teams.Any(l =>l.Leader==memberName))
            {
                WriteLine($"Member {memberName} cannot join team {teamName}!");
                continue;
            }
            teams.First(t => t.TeamName == teamName).AddMember(memberName);              
        }

        var Teams = teams.Where(tm=>tm.Members.Count>0)
            .ToDictionary(k => k.TeamName, v => v.Members.OrderBy(m=>m).ToArray());

        Teams = Teams.OrderByDescending(t => t.Value.Length).ThenBy(t => t.Key).ToDictionary(k=>k.Key,v=>v.Value);


        var disbanedTeams = teams.Where(tm => tm.Members.Count == 0).Select(v => v.TeamName).OrderBy(n=>n).ToList();

        foreach(var team in Teams)
        {
            WriteLine(team.Key);
            for (int i = -1; i < team.Value.Length; i++)
                WriteLine(i == -1 ? 
                    "- "+teams.First(t=>t.TeamName==team.Key).Leader:
                    $"-- {team.Value[i]}");
        }

        WriteLine("Teams to disband:");
        if (disbanedTeams.Count > 0)
            WriteLine($"{string.Join("\n", disbanedTeams)}");
    }
}