using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var strings = ReadLine().Split();

        WriteLine(IsExchangableWith(strings).ToString().ToLower());
    }

    static bool IsExchangableWith(string[] words)
    {
        words = words.OrderByDescending(w => w.Length).ToArray();           // words[1] shall be the smallest in length
        string tempSubstring = words[0].Length != words[1].Length ?
            words[0].Substring(words[1].Length) :
            "";

        words[0] = words[0].Substring(0, words[1].Length);

        var mappings = new Dictionary<char, char>();
        for(int i=0;i<words[1].Length;i++)
        {
            if (mappings.ContainsKey(words[0][i]))
            {
                if (mappings[words[0][i]] == words[1][i])
                    continue;
                else
                    return false;
            }
            else
                mappings[words[0][i]] = words[1][i];
        }

        for (int i = 0; i < tempSubstring.Length; i++)
        {
            if (mappings.ContainsKey(tempSubstring[i]))
                continue;
            else
                return false;
        }
        return true;
    }
}