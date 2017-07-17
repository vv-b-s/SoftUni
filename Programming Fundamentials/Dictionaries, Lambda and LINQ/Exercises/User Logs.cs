using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var UserData = new SortedDictionary<string, Dictionary<string,int>>();

        string entry;
        while((entry=ReadLine())!="end")
        {
            var userName = new string(entry.Split(' ')[2].Skip(5).ToArray());
            var IP = new string(entry.Split(' ')[0].Skip(3).ToArray());

            if (UserData.Keys.Contains(userName))
            {
                if (UserData[userName].Keys.Contains(IP))
                    UserData[userName][IP]++;
                else
                    UserData[userName][IP] = 1;
            }
            else
            {
                UserData[userName] = new Dictionary<string, int>();
                UserData[userName][IP] = 1;
            }
        }

        foreach(var user in UserData)
        {
            WriteLine(user.Key + ":");
            var dirLength = user.Value.Keys.Count;
            foreach (var IP in user.Value)
            {
                Write($"{IP.Key} => {IP.Value}{(dirLength==1?".":", ")}");
                dirLength--;
            }
            WriteLine();
        }
    }
}