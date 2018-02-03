using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class ThePartyReservationFilterModule
{
    public static void Main(string[] args)
    {
        //The key of the filters is the filter type, the value is a dictionary which key represents what the filter does and the value is the filter itself
        var filters = new Dictionary<string,Dictionary<string,Func<string, bool>>>();

        var peopleList = ReadLine().Split().AsEnumerable();

        //Operate with the filters
        var input = "";
        while((input=ReadLine())!="Print")
        {
            var data = input.Split(';');
            var operation = data[0];
            var filterType = data[1];
            var filterCriteria = data[2];

            if(operation=="Add filter")
            {
                if (!filters.ContainsKey(filterType))
                    filters[filterType] = new Dictionary<string, Func<string, bool>>();

                if(!filters[filterType].ContainsKey(filterCriteria))
                {
                    switch(filterType)
                    {
                        case "Starts with":
                            filters[filterType][filterCriteria] = person => !Regex.IsMatch(person, $@"^{filterCriteria}");
                            break;
                        case "Contains":
                            filters[filterType][filterCriteria] = person => !person.Contains(filterCriteria);
                            break;
                        case "Ends with":
                            filters[filterType][filterCriteria] = person => !Regex.IsMatch(person, $@"{filterCriteria}\b");
                            break;
                        case "Length":
                            filters[filterType][filterCriteria] = person => person.Length != int.Parse(filterCriteria);
                            break;
                    }
                }
            }
            else if(operation=="Remove filter")
            {
                filters[filterType].Remove(filterCriteria);

                if (filters[filterType].Count == 0)
                    filters.Remove(filterType);
            }
        }

        //Filter the list
        peopleList = PerformFiltration(peopleList, filters);

        WriteLine(string.Join(" ", peopleList));
    }

    private static IEnumerable<string> PerformFiltration(IEnumerable<string> listToFilter, Dictionary<string, Dictionary<string, Func<string, bool>>> filters)
    {
        foreach(var filterType in filters)
        {
            foreach(var filter in filterType.Value)
                listToFilter = listToFilter.Where(filter.Value);            
        }

        return listToFilter;
    }
}