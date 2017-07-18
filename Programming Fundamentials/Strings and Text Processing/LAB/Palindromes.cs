using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
    static void Main()
    {
        var text = ReadLine();
        var punctuations = new char[] { ' ', ',', '.', '?', '!' };

        var strings = text.Split(punctuations).Where(s=>s!="").ToArray();
        var palindromes = new List<string>();

        foreach (var word in strings)
        {
            var reversedWord = new string(word.Reverse().ToArray());
            if (reversedWord == word)
                palindromes.Add(word);
        }

        palindromes = palindromes.Distinct().ToList();
        palindromes.Sort();
        if(palindromes.Count>0)
            WriteLine(string.Join(", ", palindromes));
    }
}