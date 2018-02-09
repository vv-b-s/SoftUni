using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    //Reason your solution probably won't work: https://softuni.bg/forum/10312/jedi-code-x
    static void Main()
    {
        var numberOfLines = int.Parse(ReadLine());

        var lines = new StringBuilder();

        while (numberOfLines-- > 0)
            lines.Append(ReadLine());

        var namePrefix = ReadLine();
        var messagePrefix = ReadLine();

        var namePattern = new Regex($@"{namePrefix}(?<name>[A-Za-z]{'{'}{namePrefix.Length}{'}'})(?!([a-zA-Z]))");
        var messagePattern = new Regex($@"{messagePrefix}(?<message>[A-Za-z0-9]{'{'}{messagePrefix.Length}{'}'})(?![a-zA-Z0-9])");

        var messages = new List<string>();
        var jedis = new List<string>();



        messages = messages.Concat(messagePattern.Matches(lines.ToString()).Cast<Match>().Select(m => m.Groups["message"].Value)).ToList();
        jedis = jedis.Concat(namePattern.Matches(lines.ToString()).Cast<Match>().Select(m => m.Groups["name"].Value)).ToList();


        var indexes = new Queue<int>(ReadLine().Split().Where(i => i != "").Select(i => int.Parse(i) - 1));

        for (int i = 0; i < jedis.Count && indexes.Count > 0; i++)
        {
            var index = 0;
            while (indexes.Count > 0 && MessageDoesNotExist(index = indexes.Dequeue(), messages.Count)) ;

            if (!MessageDoesNotExist(index, messages.Count))
                WriteLine(jedis[i] + " - " + messages[index]);
        }
    }

    private static bool MessageDoesNotExist(int index, int messagesCount) => !(messagesCount > index && index >= 0);
}