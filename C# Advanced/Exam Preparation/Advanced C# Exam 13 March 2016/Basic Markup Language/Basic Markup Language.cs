using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input;
        var line = 1;
        var pattern = new Regex("<\\s*(?<command>\\w+)\\s+(value\\s*=\\s*\"\\s*(?<value>\\d+)\\s*\"\\s+)?content\\s*=\\s*\"(?<content>.+)\"\\s*\\/\\s*>");

        while((input=ReadLine())!= @"<stop/>")
        {
            if(pattern.IsMatch(input))
            {
                var match = pattern.Match(input);
                var command = match.Groups["command"].Value;
                var content = match.Groups["content"].Value;


                switch(command)
                {
                    case "inverse":
                        var sB = new StringBuilder();
                        foreach(var letter in content)
                        {
                            if (char.IsUpper(letter))
                                sB.Append(char.ToLower(letter));
                            else if (char.IsLower(letter))
                                sB.Append(char.ToUpper(letter));
                            else sB.Append(letter);
                        }
                        WriteLine($"{line}. {sB}");
                        line++;
                        break;
                    case "reverse":
                        WriteLine($"{line}. {new string(content.Reverse().ToArray())}");
                        line++;
                        break;
                    case "repeat":
                        sB = new StringBuilder();
                        var value = int.Parse(match.Groups["value"].Value);
                        for (int i = 0; i < value; i++)
                        {
                            sB.AppendLine($"{line}. {content}");
                            line++;
                        }
                        if(sB.Length>0)
                            Write(sB);
                        break;
                }
            }
        }
    }
}