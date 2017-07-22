using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using static System.Console;
using System.Net;

class Program
{
    static void Main()
    {
        string stringOtext = File.ReadAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\More exercises\Resources\sample_text.txt");
        var punctuations = new List<char>();
        var acceptedPunct = new char[] { '.', ',', '!', '?', ':' };
        foreach (var ch in stringOtext)
            if (acceptedPunct.Contains(ch))
                punctuations.Add(ch);
        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\More exercises\Punctuation finder\output.txt",string.Join(", ", punctuations));
    }
}