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
        var sB = new StringBuilder();
        for (int i = int.Parse(ReadLine()); i > 0; i--)
            sB.AppendLine(ReadLine());

        var validEmails = Regex.Matches(sB.ToString(), @"(?<username>[a-zA-Z]{5,})+@(?<domain>[a-z]{3,}\.(com|bg|org))\b");
        var domainUsers = new Dictionary<string, List<string>>();
        foreach(Match email in validEmails)
        {
            var domain = email.Groups["domain"].Value;
            var username = email.Groups["username"].Value;

            if(domainUsers.ContainsKey(domain))
            {
                if (domainUsers[domain].Contains(username))
                    continue;
                domainUsers[domain].Add(username);
                continue;
            }

            domainUsers[domain] = new List<string> { username };
        }

        domainUsers = domainUsers.OrderByDescending(dU => dU.Value.Count).ToDictionary(k => k.Key, v => v.Value);

        foreach(var domain in domainUsers)
        {
            WriteLine(domain.Key+":");
            Write(ExtractUsers(domain.Value));
        }
    }

    private static string ExtractUsers(List<string> usernames)
    {
        var sB = new StringBuilder();
        foreach (var user in usernames)
            sB.AppendLine($"### {user}");
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