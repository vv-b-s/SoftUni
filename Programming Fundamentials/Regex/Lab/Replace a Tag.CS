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
        var pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
        var text = new StringBuilder();
        string input;
        while ((input = ReadLine()) != "end")
            text.AppendLine(input);
        var newText = Regex.Replace(text.ToString(),pattern, @"[URL href=$1]$2[/URL]");    // only the group members are kept

        WriteLine(newText);
    }

}