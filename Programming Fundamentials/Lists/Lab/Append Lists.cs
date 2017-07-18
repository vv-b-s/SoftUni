using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var raw = ReadLine().Split('|');
        Array.Reverse(raw);

        var lists = new List<string>[raw.Length];
        for(int i=0;i<raw.Length;i++)
        {
            lists[i] = raw[i].Trim().Split(' ').ToList();
            lists[i].RemoveAll(t => t == "");
        }

        foreach (var list in lists)
            Write(string.Join(" ", list) + " ");
        WriteLine();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}