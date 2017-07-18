using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Deamon
{
    public string Name { set; get; }
    public decimal Health { set; get; }
    public decimal Damage { set; get; }

    public Deamon(string name)
    {
        Name = name;
        var lettersInName = string.Join("", Regex.Matches(name, @"[^0-9\-*\/+.]").Cast<Match>().Select(m => m.Value).ToArray());
        Health = lettersInName.Sum(l => l);

        var symbolsInName = Regex.Matches(name, @"-*\d+(\.\d+)?|[*\/]").Cast<Match>().Select(m => m.Value).ToArray();

        var numbers = symbolsInName.Where(s=>Regex.IsMatch(s, @"-*\d+(\.\d+)?")).Select(decimal.Parse).ToList();
        var operators = symbolsInName.Where(s=> Regex.IsMatch(s, @"[*\/]")).Select(char.Parse).ToList();

        Damage = numbers.Sum();
        foreach (var op in operators)
            switch (op)
            {
                case '/':
                    Damage/= 2; break;
                case '*':
                    Damage *= 2; break;
            }

    }
}

class Program
{
    static void Main()
    {
        var deamons = Regex.Split(ReadLine(), @"[,\s]+").Select(d => new Deamon(d)).OrderBy(d => d.Name).ToList();
        foreach (var deamon in deamons)
            WriteLine($"{deamon.Name} - {deamon.Health} health, {deamon.Damage:f2} damage");
    }
}