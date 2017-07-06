using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var beehives = ReadLine().Split().Where(b => b != "").Select(long.Parse).ToList();
        var hornets = ReadLine().Split().Where(h => h != "").Select(long.Parse).ToList();

        for (int i = 0; i < beehives.Count; i++)
        {
            var hornetPower = hornets.Sum();
            if (hornetPower <= beehives[i])
                hornets.RemoveAt(0);
            beehives[i] -= hornetPower;
            if (hornets.Count == 0)
                break;
        }
        beehives = beehives.Where(bh => bh > 0).ToList();

        if (beehives.Count > 0)
            WriteLine(string.Join(" ", beehives));
        else
            WriteLine(string.Join(" ", hornets));
    }
}