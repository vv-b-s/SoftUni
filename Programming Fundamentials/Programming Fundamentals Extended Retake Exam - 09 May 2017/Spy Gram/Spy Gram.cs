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
        var validMessages = new SortedDictionary<string,List<string>>();
        var key = ReadLine();
        string input;
        while((input=ReadLine())!="END")
        {
            var pattern = new Regex(@"^TO:\s(?<sender>[A-Z]+);\sMESSAGE:\s[^;]+;$");
            if (pattern.IsMatch(input))
            {
                var sender = pattern.Match(input).Groups["sender"].Value;
                if (validMessages.ContainsKey(sender))
                    validMessages[sender].Add(input);
                else validMessages[sender] = new List<string> { input };
            }
        }

        foreach(var validMessage in validMessages)
        {
            for (int i = 0; i < validMessage.Value.Count; i++)
            {
                var sB = new StringBuilder();
                for (int j = 0; j < validMessage.Value[i].Length; j++)
                    sB.Append((char)(validMessage.Value[i][j] + char.GetNumericValue(key[j % key.Length])));
                validMessage.Value[i] = sB.ToString();
            }
        }

        var encryptedMSG = validMessages.Values.SelectMany(v => v).ToList();
        WriteLine(string.Join("\n", encryptedMSG));
    }
}
