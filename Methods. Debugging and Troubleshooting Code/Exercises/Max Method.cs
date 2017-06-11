using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(GetMax((int)ReadNum(), (int)ReadNum(), (int)ReadNum()));
    }

    static string GetMax(params int[] number)
    {
        int temp = number[0];
        foreach (var num in number)
            temp = num > temp ? num : temp;
        return temp.ToString();
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
