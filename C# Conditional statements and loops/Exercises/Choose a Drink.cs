using System;
using static System.Console;

class Program
{
    [Flags]
    enum Profession { Athlete, Businessman, Businesswoman = 1, SoftUni }
    enum Drink { Water, Coffee, Beer, Tea }
    static void Main()
    {
        Profession prof;
        bool check = Enum.TryParse(ReadLine().Split()[0], out prof);
        WriteLine(check? ((Drink)prof).ToString() : ((Drink)3).ToString());
    }
}
