using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class User
{
    int durutation = 0;

    public List<string> IPs = new List<string>();
    public int Durutation
    {
        set { durutation += value; }
        get { return durutation; }
    }
}

class Program
{
    static void Main()
    {
        var log = new SortedDictionary<string, User>();
        int logCount = int.Parse(ReadLine());

        for(int i =0;i<logCount;i++)
        {
            string data = ReadLine();
            string ip = data.Split()[0];
            string userName = data.Split()[1];
            int durutation = int.Parse(data.Split()[2]);

            if(log.Keys.Contains(userName))
            {
                log[userName].Durutation = durutation;
                log[userName].IPs.Add(ip);
            }
            else
            {
                log[userName] = new User();
                log[userName].Durutation = durutation;
                log[userName].IPs.Add(ip);
            }
        }

        foreach (var userLog in log)
        {
            userLog.Value.IPs.Sort();
            WriteLine($"{userLog.Key}: {userLog.Value.Durutation} [{string.Join(", ", userLog.Value.IPs.Distinct().ToList())}]");
        }
    }
}