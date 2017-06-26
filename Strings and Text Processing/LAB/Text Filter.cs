using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
    static void Main()
    {
        var bannedWords = ReadLine().Split(' ', ',').Where(s => s != "").ToList();
        var text = new StringBuilder(ReadLine());

        foreach (var word in bannedWords)
            text.Replace(word, new string('*', word.Length));

        WriteLine(text.ToString());
    }
}