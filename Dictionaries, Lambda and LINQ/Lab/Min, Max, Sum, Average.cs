using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var inputLength = int.Parse(ReadLine());
        var numbers = new List<int>();

        for(int i=0;i<inputLength;i++)
            numbers.Add((int)ReadNum());

        WriteLine($"Sum = {numbers.Sum()}\n" +
            $"Min = {numbers.Min()}\n" +
            $"Max = {numbers.Max()}\n" +
            $"Average = {numbers.Average()}");
        
    }

    static string[] CleanArray(string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        return raw.ToArray();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}