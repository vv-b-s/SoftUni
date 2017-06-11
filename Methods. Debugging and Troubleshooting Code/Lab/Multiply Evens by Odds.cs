using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(MultiplySumEvenOds(ReadLine()));
    }

    static int MultiplySumEvenOds(string number)
    {
        number = number.Contains("-") ? number.Remove(0, 1) : number;
        int oddSum = 0, evenSum = 0;
        for(int i=0;i<number.Length;i++)
        {
            if (Char.GetNumericValue(number[i]) % 2 == 0)
                oddSum += (int)Char.GetNumericValue(number[i]);
            else
                evenSum += (int)Char.GetNumericValue(number[i]);
        }
        return oddSum * evenSum;
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
