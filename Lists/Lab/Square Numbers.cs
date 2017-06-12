using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var rawList = CleanArray(ReadLine().Trim().Split()).Select(double.Parse).ToList();

        var sqrNumber = new List<double>();
        foreach (var item in rawList)
            if (Math.Sqrt(item) % 1 == 0)
                sqrNumber.Add(item);

        sqrNumber.Sort();
        sqrNumber.Reverse();

        WriteLine(string.Join(" ", sqrNumber));
    }

    static string[] CleanArray(string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        return raw.ToArray();
    }
}