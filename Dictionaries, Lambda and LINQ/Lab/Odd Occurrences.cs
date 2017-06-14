using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var text = ReadLine().ToLower().Split();
        var words = new Dictionary<string, int>();

        foreach(var word in text)
        {
            if (words.Keys.Contains(word))
                words[word]++;
            else
                words.Add(word, 1);
        }

        var output = new List<string>();
        foreach (var item in words)
            if (item.Value % 2 != 0)
                output.Add(item.Key);

        WriteLine(string.Join(", ", output));
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