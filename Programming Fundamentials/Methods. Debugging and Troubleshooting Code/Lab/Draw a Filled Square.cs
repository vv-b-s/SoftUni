using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(Square((int)ReadNum()));
    }

    static string Square(int size) =>
        $"{DrawTopOrBottom(size)}\n" +
        $"{DrawInnerFill(size)}" +
        $"{DrawTopOrBottom(size)}";

    static string DrawTopOrBottom(int size) => new string('-', size * 2);
    static string DrawInnerFill(int size)
    {
        var sB = new StringBuilder();
        for(int i=0;i<size-2;i++)
        {
            sB.Append("-");
            for (int j = 0; j < size * 2 - 2; j++)
                sB.Append(j % 2 == 0 ? "\\" : "/");
            sB.AppendLine("-");
        }
        return sB.ToString();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
