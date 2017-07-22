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
        var stringOtext = File.ReadAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\More exercises\Resources\sample_text.txt").ToList<char>();
        var acceptedPunct = new char[] { '.', ',', '!', '?', ':' };
        var newText = new char[stringOtext.Count];
        var newPos = 0;
        for(int i=0;i<stringOtext.Count;i++)
        {
            if (acceptedPunct.Contains(stringOtext[i]))
                continue;
            newText[newPos] = stringOtext[i];
            newPos++;
        }
        var outArr = new char[newPos + 1];
        for(int i=0;i<outArr.Length;i++)
            outArr[i] = newText[i];
        

        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\More exercises\Write to file\output.txt", new string(outArr));
    }
}