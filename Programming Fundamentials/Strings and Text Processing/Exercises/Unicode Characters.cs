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
        var chars = ReadLine().ToCharArray();
        WriteLine(ConvertToHexText(chars));
    }

    static string ConvertToHexText(char[] chars)
    {
        var sB = new StringBuilder();
        foreach (var ch in chars)
            sB.Append($"\\u{GetHex(ch)}");
        return sB.ToString();
    }

    static string GetHex(char symbol)
    {
        string hex = Convert.ToString(symbol, 16);
        var sB = new StringBuilder();
        var numberOfZeros = 4-hex.Length;

        for(int i=0;i<numberOfZeros+1;i++)
            sB.Append(i < numberOfZeros ? "0" : hex);

        return sB.ToString();
    }
}