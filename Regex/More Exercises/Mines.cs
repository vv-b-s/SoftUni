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

        var text = FindAndBlowMines(ReadLine());

        WriteLine(text);
    }


    private static string FindAndBlowMines(string text)
    {
        var minePattern = new Regex(@"(?<=<)\w+(?=>)");
        var mineDigit = new Queue<int>();

        foreach (Match match in minePattern.Matches(text))
        {
            var matchToSTring = match.Value;
            int absoluteMatchSubstract = matchToSTring[0];

            for (int i = 1; i < matchToSTring.Length; i++)
                absoluteMatchSubstract -= matchToSTring[i];
            absoluteMatchSubstract = Math.Abs(absoluteMatchSubstract);

            mineDigit.Enqueue(absoluteMatchSubstract);
        }

        while(mineDigit.Count!=0)
        {
            var digit = mineDigit.Dequeue();
            var mineSpan = new Regex($@".{AddVar($"0,{digit}")}<\w+>.{AddVar($"0,{digit}")}");
            var mineSpanLen = mineSpan.Match(text).Length;
            text = mineSpan.Replace(text, new string('_', mineSpanLen),1);
        }

        return text;
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