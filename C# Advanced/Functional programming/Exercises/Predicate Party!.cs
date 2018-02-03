using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class PredicateParty
{
    private static List<string> partyList;
    public static void Main(string[] args)
    {
        partyList = ReadLine().Split().ToList();

        var input = "";
        while((input = ReadLine())!="Party!")
        {
            var data = input.Split().Where(s=>s!="").ToArray();
            var command = data[0];
            var criteria = data[1];
            var argument = data[2];

            if(command=="Double")
            {
                switch(criteria)
                {
                    case "StartsWith":
                        LoadPeopleGoingToParty(person => Regex.IsMatch(person, $@"^{argument}"));
                        break;
                    case "EndsWith":
                        LoadPeopleGoingToParty(person => Regex.IsMatch(person, $@"{argument}\b"));
                        break;
                    case "Length":
                        var length = int.Parse(argument);
                        LoadPeopleGoingToParty(person => person.Length == length);
                        break;
                }
            }
            else if(command=="Remove")
            {
                switch(criteria)
                {
                    case "StartsWith":
                        RemovePeopleFromList(person => Regex.IsMatch(person, $@"^{argument}"));
                        break;
                    case "EndsWith":
                        RemovePeopleFromList(person => Regex.IsMatch(person, $@"{argument}\b"));
                        break;
                    case "Length":
                        var length = int.Parse(argument);
                        RemovePeopleFromList(person => person.Length == length);
                        break;
                }
            }
        }

        WriteLine(partyList.Count > 0 ? string.Join(", ", partyList) + " are going to the party!" : "Nobody is going to the party!");
    }

    public static void LoadPeopleGoingToParty(Predicate<string> decideCriteria)
    {
        var peopleToAdd = new List<string>();
        for(int i=0;i<partyList.Count;i++)
        {
            peopleToAdd.Add(partyList[i]);
            if (decideCriteria(partyList[i]))
                peopleToAdd.Add(partyList[i]);
        }

        partyList = peopleToAdd;
    }

    public static void RemovePeopleFromList(Predicate<string> decideCriteria)
    {
        for(int i = 0;i<partyList.Count;i++)
        {
            if (decideCriteria(partyList[i]))
            {
                partyList.RemoveAt(i);
                i--;
            }
        }
    }
}