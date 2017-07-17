using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(CompareVariables(ReadLine(), ReadLine(), ReadLine()));
    }

    static string CompareVariables(string type, string a, string b)
    {
        switch (type)
        {
            case "int":
                int[] numbers = { int.Parse(a), int.Parse(b) };
                return (numbers[0] > numbers[1] ? numbers[0] : numbers[1]).ToString();
            case "char":
                return a[0] > b[0] ? a : b;
            case "string":
                return a.CompareTo(b)>=0 ? a : b;
            default:
                return null;
        }
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
