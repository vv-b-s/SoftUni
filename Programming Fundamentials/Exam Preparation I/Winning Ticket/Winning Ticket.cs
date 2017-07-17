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
        var ticets = Regex.Split(ReadLine(), @"[\s,]+");
        foreach(var ticket in ticets)
        {
            if (ticket.Length == 20)
            {
                var substring = new string[] { ticket.Substring(0, 10), ticket.Substring(10, 10) };

                var winningSymbols = new char[] { '@', '#', '$', '^' };
                var winSym = new char();

                foreach (var symbol in winningSymbols)
                    if (Regex.IsMatch(substring[0], $@"\{symbol}{AddVar("6,")}") && Regex.IsMatch(substring[1], $@"\{symbol}{AddVar("6,")}"))
                        winSym = symbol;

                var count = substring[0].Count(s=>s==winSym)==substring[1].Count(c=>c==winSym)? 
                    substring[1].Count(c => c == winSym):
                    substring.Min(s=>s.Count(c=>c==winSym));

                if (count >= 6 && count <= 9)
                    WriteLine($"ticket \"{ ticket}\" - {count}{winSym}");
                else if (count >= 10)
                    WriteLine($"ticket \"{ ticket}\" - {count}{winSym}{(substring[0] == substring[1] ? " Jackpot!" : "")}");
                else
                    WriteLine($"ticket \"{ ticket}\" - no match");
            }
            else
                WriteLine("invalid ticket");
        }
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