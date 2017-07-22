using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string words = ReadLine();
        char char1 = char.Parse(ReadLine());
        char char2 = char.Parse(ReadLine());
        char char3 = char.Parse(ReadLine());
        string words2 = ReadLine();

        WriteLine($"{words}\n" +
                  $"{char1}\n" +
                  $"{char2}\n" +
                  $"{char3}\n" +
                  $"{words2}");
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
