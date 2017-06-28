using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var input = ReadLine().Split().Select(s => s.Trim()).Where(s => s != "").ToList();
        var numbers = new List<double>();
        foreach(var str in input)
        {
            var number = double.Parse(str.Substring(1, str.Length - 2));

            if (char.IsLower(str[0]))
                number *= (str[0] - 96);
            if (char.IsUpper(str[0]))
                number /= (str[0] - 64);
            if(char.IsLower(str[str.Length-1]))
                number += (str[str.Length - 1] - 96);
            if (char.IsUpper(str[str.Length - 1]))
                number -= (str[str.Length-1] - 64);

            numbers.Add(number);
        }

        WriteLine($"{Math.Round(numbers.Sum(), 2,MidpointRounding.AwayFromZero):f2}");
    }

}