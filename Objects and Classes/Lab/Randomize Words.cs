using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Program
{
    static void Main()
    {
        var words = ReadLine().Split().ToList();
        var rand = new Random();
        var randomisedWords = new List<string>();
        while(randomisedWords.Count!=words.Count)
        {
            string randWord = words[rand.Next(words.Count)];
            if (!randomisedWords.Contains(randWord))
                randomisedWords.Add(randWord);
        }
        WriteLine(string.Join("\n", randomisedWords));
    }
}