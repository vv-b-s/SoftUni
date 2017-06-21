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
        var words = File.ReadAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Word Count\words.txt").Split();

        var dict = new Dictionary<string, int>();
        foreach (var word in words)
            dict[word] = 0;

        var input = File.ReadAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Word Count\Input.txt")
            .Split(' ', ',', '-', '.','?','!','\r','\n')
            .Where(w=>w!="")
            .ToArray();

        foreach(var word in input)
        {
            if (dict.ContainsKey(word.ToLower()))
                dict[word.ToLower()]++;
        }

        dict = dict.OrderByDescending(w => w.Value).ToDictionary(k => k.Key, v => v.Value);

        var sB = new StringBuilder();
        foreach (var word in dict)
            sB.AppendLine(word.Key + " - " + word.Value);

        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Word Count\Output.txt", sB.ToString());
    }
}