using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class User
{
    public string Username { set; get; }
    public List<string> Comments { set; get; }
    public List<DateTime> Dates { set; get; }

    public User(string username, List<string> dates)
    {
        Username = username;
        Comments = new List<string>();
        Dates = dates.Count>0 ?
            dates.Select(d=>DateTime.ParseExact(d,"dd/MM/yyyy",CultureInfo.InvariantCulture))
            .OrderBy(d=>d.Date).ToList():
            new List<DateTime>();
    }

    public void AddDates(List<string> dates) => Dates = dates.Count > 0 ?
        Dates.Concat(dates.Select(d => DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
        .OrderBy(d => d.Date).ToList() :
        Dates;

    public void AddComment(string comment) => Comments.Add(comment);
}

class Program
{
    static void Main()
    {
        var users = new List<User>();

        string input;
        while((input = ReadLine())!="end of dates")
        {
            var temp = input.Split();
            string username = temp[0];
            var dates = temp.Length > 1 ? input.Split()[1].Split(',').ToList() : new List<string>();

            if (users.Any(u => u.Username == username))
                users.First(u => u.Username == username).AddDates(dates);
            else
                users.Add(new User(username, dates));
        }

        users = users.OrderBy(u => u.Username).ToList();

        while((input=ReadLine())!="end of comments")
        {
            string username = input.Split('-')[0];
            string comment = input.Split('-')[1];

            if (users.Any(u => u.Username == username))
                users.First(u => u.Username == username).AddComment(comment);             
        }

        foreach(var user in users)
        {
            WriteLine($"{user.Username}\n" +
                $"Comments:");
            foreach (var comment in user.Comments)
                WriteLine($"- {comment}");

            WriteLine("Dates attended:");

            if(user.Dates.Count>0)
                foreach (var date in user.Dates)
                    WriteLine($"-- {date.Date.ToString("dd/MM/yyyy").Replace('-', '/')}");
        }
    }
}