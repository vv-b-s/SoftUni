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
        var numbers = Regex.Split(ReadLine(), @"\s").Select(int.Parse).ToList();

        string input;
        while ((input = ReadLine()) != "end")
        {
            var command = input.Split()[0];

            switch (command)
            {
                case "exchange":
                    var index = int.Parse(input.Split()[1]);
                    ExchangeArray(ref numbers, index);
                    break;

                case "max":
                    var oddOrEven = input.Split()[1];
                    WriteLine(IndexOfOddOrEven(numbers, oddOrEven, "max"));
                    break;

                case "min":
                    oddOrEven = input.Split()[1];
                    WriteLine(IndexOfOddOrEven(numbers, oddOrEven, "min"));
                    break;

                case "first":
                    var count = int.Parse(input.Split()[1]);
                    if (count <= numbers.Count)
                    {
                        oddOrEven = input.Split()[2];
                        WriteLine($"[{FistElements(numbers, count, oddOrEven)}]");
                        break;
                    }
                    else
                    {
                        WriteLine("Invalid count");
                        break;
                    }

                case "last":
                    count = int.Parse(input.Split()[1]);
                    if (count <= numbers.Count)
                    {
                        oddOrEven = input.Split()[2];
                        WriteLine($"[{LastElements(numbers, count, oddOrEven)}]");
                        break;
                    }
                    else
                    {
                        WriteLine("Invalid count");
                        break;
                    }
            }
        }

        WriteLine($"[{string.Join(", ", numbers)}]");
    }

    private static string LastElements(List<int> numbers, int count, string oddOrEven)
    {
        switch (oddOrEven)
        {
            case "odd":
                var oddEntities = numbers.Where(n => n % 2 != 0).ToList();
                oddEntities.Reverse();

                var lastOdd = oddEntities.Take(count).ToList();
                lastOdd.Reverse();

                return string.Join(", ", lastOdd);
            case "even":
                var evenEntinies = numbers.Where(n => n % 2 == 0).ToList();
                evenEntinies.Reverse();

                var lastEven = evenEntinies.Take(count).ToList();
                lastEven.Reverse();

                return string.Join(", ", lastEven);
            default:
                return "";
        }
    }


    private static string FistElements(List<int> numbers, int count, string oddOrEven)
    {
        switch(oddOrEven)
        {
            case "odd":
                var oddEntities = numbers.Where(n => n % 2 != 0).ToList();
                var firstOdd = oddEntities.Take(count).ToList();
                return string.Join(", ", firstOdd);
            case "even":
                var evenEntinies = numbers.Where(n => n % 2 == 0).ToList();
                var firstEven = evenEntinies.Take(count).ToList();
                return string.Join(", ", firstEven);
            default:
                return "";
        }
    }

    private static string IndexOfOddOrEven(List<int> numbers, string oddOrEven, string minOrMax)
    {
        switch(oddOrEven)
        {
            case "odd":
                if (!numbers.Any(n=>n%2!=0))
                    break;
                else
                    return minOrMax=="min"?
                        numbers.LastIndexOf(numbers.OrderBy(n=>n).First(n=>n%2!=0)).ToString():
                        numbers.LastIndexOf(numbers.OrderByDescending(n => n).First(n => n % 2 != 0)).ToString();
            case "even":
                if (!numbers.Any(n => n % 2 == 0))
                    break;
                else
                    return minOrMax == "min" ?
                        numbers.LastIndexOf(numbers.OrderBy(n => n).First(n => n % 2 == 0)).ToString() :
                        numbers.LastIndexOf(numbers.OrderByDescending(n => n).First(n => n % 2 == 0)).ToString();
        }
        return "No matches";
    }

    private static void ExchangeArray(ref List<int> numbers, int index)
    {
        if (index < 0 || index > numbers.Count - 1)
            WriteLine("Invalid index");

        var subArray = numbers.Skip(index + 1).ToList();
        numbers = subArray.Concat(numbers.Take(index + 1)).ToList();
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