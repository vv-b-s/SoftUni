using System;
using System.Linq;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string arrayInString = ReadLine();
        double[] array = Array.ConvertAll(arrayInString.Split(' '), double.Parse);

        foreach (double t in array)
            WriteLine($"{t} => {RoundAccurate(t)}");
    }

    static double RoundAccurate(double number)
    {
        double temp = number - (int) number;
        return Math.Abs(temp) >= 0.5 ? (int) number + (number > 0 ? 1 : - 1) : (int) number;
    }

    static void PrintArray<TArray>(TArray[] arr)
    {
        foreach (var item in arr)
            Write($"{item} ");

        WriteLine();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
