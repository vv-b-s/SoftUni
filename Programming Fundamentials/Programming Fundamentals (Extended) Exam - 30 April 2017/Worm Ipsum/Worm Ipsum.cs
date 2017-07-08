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
        string input;
        while((input=ReadLine())!= "Worm Ipsum")
        {
            if (Regex.IsMatch(input, @"^[A-z][^\.]+\.$"))
            {
                var words = input.Split().ToList();
                for(int i=0;i<words.Count;i++)
                {
                    char temp;
                    if (GetMostRepeatedChar(words[i], out temp))
                        words[i] = Regex.Replace(words[i], @"\w", $"{temp}");
                }
                WriteLine(string.Join(" ", words));
            }
        }
    }

    private static bool GetMostRepeatedChar(string word, out char result)
    {
        var charCount = new Dictionary<char, int>();
        foreach(var ch in word)
        {
            if (charCount.ContainsKey(ch))
                charCount[ch]++;
            else
                charCount[ch] = 1;
        }
        result = charCount.First(ch => ch.Value == charCount.Values.Max()).Key;

        if (charCount.Values.All(ch => ch == charCount.First().Value))
            return false;
        return true;
    }
}
