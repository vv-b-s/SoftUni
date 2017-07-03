using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class MessageGenerator
{
    static private List<string> phrases = new List<string> {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};
    static private List<string> events  = new List<string> { "Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
    static private List<string> authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
    static private List<string> cities  = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

    public static string GenerateMessages(int numberOfMessages)
    {
        var messages = new StringBuilder();
        var rand = new Random();

        for (int i = 0; i < numberOfMessages; i++)
            messages.AppendLine($"{phrases[rand.Next(phrases.Count)]} {events[rand.Next(events.Count)]} {authors[rand.Next(authors.Count)]} – {cities[rand.Next(cities.Count)]}");

        return messages.ToString();
    }
}

class Program
{
    static void Main()
    {
        Write(MessageGenerator.GenerateMessages(int.Parse(ReadLine())));
    }
}