using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Most frequent number\input.txt");
        var output = new StringBuilder();
        
        foreach(var line in lines)
        {
            int[] numbers = Array.ConvertAll(line.Split(), int.Parse);
            var numberCount = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (numberCount.ContainsKey(number))
                    numberCount[number]++;
                else
                    numberCount[number] = 0;
            }
            int maxCount = numberCount.Values.Max();
            output.AppendLine(numberCount.First(n => n.Value == maxCount).Key.ToString());
        }
        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Most frequent number\output.txt",output.ToString());
    }
}