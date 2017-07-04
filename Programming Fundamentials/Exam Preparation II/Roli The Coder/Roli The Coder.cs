using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Event
{
    public string LogNumber { set; get; }
    public string EventName { set; get; }

    private List<string> users = new List<string>();
    public List<string> Users => users;

    public Event(string logNumber, string eventName,List<string> users)
    {
        LogNumber = logNumber;
        EventName = eventName;

        AddUsers(users);
    }

    public void AddUsers(List<string> users)
    {
        foreach(var user in users)
        {
            if (this.users.Contains(user))
                continue;
            this.users.Add(user);
        }
    }

    public void OrderUsers() => users = users.OrderBy(u => u).ToList();
}
class Program
{
    static void Main()
    {
        var events = new Dictionary<string, Event>();

        string input;
        while ((input = ReadLine()) != "Time for Code")
            if (Regex.IsMatch(input, @"[0-9a-zA-Z]+\s+#[0-9a-zA-Z]+\s*(@[a-zA-Z]+\s*)*"))
            {
                var temp = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var id = temp[0];
                var eventName = temp[1].Substring(1);
                var users = temp.Skip(2).ToList();

                if (events.ContainsKey(id) && events[id].EventName == eventName)
                    events[id].AddUsers(users);
                else if (!events.ContainsKey(id) && !events.Values.Any(e => e.EventName == eventName))
                    events[id] = new Event(id, eventName, users);
            }      

        events = events.OrderByDescending(e => e.Value.Users.Count).ThenBy(e=>e.Value.EventName).ToDictionary(k => k.Key, v => v.Value);

        foreach(var eventlog in events)
        {
            eventlog.Value.OrderUsers();
            WriteLine($"{eventlog.Value.EventName} - {eventlog.Value.Users.Count}");
            if(eventlog.Value.Users.Count>0)
                WriteLine(string.Join("\n", eventlog.Value.Users));
        }
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