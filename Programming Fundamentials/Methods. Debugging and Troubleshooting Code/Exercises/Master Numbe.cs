using System;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        int endNumber = (int)ReadNum();
        for (int i = 0; i <= endNumber; i++)
            if (IsMasterNumber(i.ToString()))
                WriteLine(i);
    }

    static bool IsMasterNumber(string number) => IsSymmetric(number) && IsDivisibleBySeven(number) && HasEvenDigit(number);

    static bool IsSymmetric(string number)
    {
        if (number.Length < 3)
            return false;

        int[] loopStart =
        {
            number.Length % 2 == 0 ? number.Length/2-1 : number.Length/2-1,
            number.Length % 2 == 0 ? number.Length/2 : number.Length/2+1
        };
        for (int i =loopStart[0],j=loopStart[1]; i >= 0; i--,j++)
            if (number[i] != number[j])
                return false;

        return true;
    }
    static bool IsDivisibleBySeven(string number)
    {
        int sumOfDigits = 0;
        foreach (var a in number)
            sumOfDigits += a-48;
        return sumOfDigits % 7 == 0;
    }

    static bool HasEvenDigit(string number)
    {
        foreach (var a in number)
            if (a % 2 == 0)
                return true;
        return false;
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
