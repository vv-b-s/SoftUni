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
        var validMessages = new Dictionary<string, string>();

        string input;
        while ((input = ReadLine()) != "Over!")
        {
            var inputLen = int.Parse(ReadLine());
            var pattern = new Regex($@"^(\d+)([A-Za-z]{AddVar($"{inputLen}")})([^A-Za-z]*)$");

            if (pattern.IsMatch(input))
            {
                var firstMessagePart = pattern.Match(input).Groups[1].Value;
                var message = pattern.Match(input).Groups[2].Value;
                var lastMessagePart = pattern.Match(input).Groups[3].Value;

                var decryptedMessage = DecryptMessage(firstMessagePart, message, lastMessagePart);

                validMessages[message] = decryptedMessage;
            }
        }

        foreach (var message in validMessages)
        {
            WriteLine($"{message.Key} == {message.Value}");
        }
    }

    private static string DecryptMessage(string firstMessagePart, string message, string lastMessagePart)
    {
        var Indexes = firstMessagePart
            .ToCharArray()
            .Select(char.GetNumericValue)
            .Concat(
            lastMessagePart
            .Where(c => char.IsDigit(c))
            .Select(char.GetNumericValue))
            .ToArray();

        var sB = new StringBuilder();
        foreach (var i in Indexes)
        {
            sB.Append(i >= 0 && i <= message.Length - 1 ?
                message[(int)i].ToString() :
                " ");
        }

        return sB.ToString();
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