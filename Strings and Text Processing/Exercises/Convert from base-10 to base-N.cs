using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static System.Console;

class Program
{
    static void Main()
    {
        string[] input = ReadLine().Split();

        var nBase = int.Parse(input[0]);
        var number = BigInteger.Parse(input[1]);

        WriteLine(BaseConverter(number,nBase));
    }

    private static string BaseConverter(BigInteger decNumber, int nBase)
    {
        string digits = "0123456789ABCDEF";

        var remstack = new Stack<int>();

        while(decNumber>0)
        {
            int rem = (int)(decNumber % (BigInteger)nBase);
            remstack.Push(rem);
            decNumber /= (BigInteger)nBase;
        }

        var newString = new StringBuilder();
        while (remstack.Count != 0)
            newString.Append(digits[remstack.Pop()]);

        return newString.ToString();
    }
}