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
        var paragraphs = Regex.Matches(ReadLine(), @"(?<=<p>)[^\/]+(?=<\/p>)").Cast<Match>().Select(m => m.Value).ToList();
        for (int i = 0; i < paragraphs.Count; i++)
        {
            paragraphs[i] = Regex.Replace(paragraphs[i], @"[^a-z0-9]+", " ");
            var newWord = new StringBuilder();
            for (int j = 0; j < paragraphs[i].Length; j++)
                newWord.Append(char.IsLower(paragraphs[i][j]) && char.IsLetter(paragraphs[i][j]) ?
                    (char)((paragraphs[i][j] - 97 + 13) % 26 + 97) :
                    paragraphs[i][j]);
            paragraphs[i] = newWord.ToString();
        }

        WriteLine(string.Join("", paragraphs).Trim());
    }

    static string AddVar(string value)
    {
        var sB = new StringBuilder();
        sB.Append('{');
        sB.Append(value);
        sB.Append('}');
        return sB.ToString();
    }

}