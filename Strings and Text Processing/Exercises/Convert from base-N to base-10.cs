//http://mathbits.com/MathBits/CompSci/Introduction/tobase10.htm

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
        var number = input[1];

        WriteLine(BaseConverter(number,nBase));
    }

    private static string BaseConverter(string number, int nBase)
    {
        string digits = "0123456789ABCDEF";
        var numbers = number.ToCharArray().ToList();

        var remstack = new Stack<int>();

        while(numbers.Count>0)
        {
            int index = digits.IndexOf(numbers[0]);
            remstack.Push(index);
            numbers.RemoveAt(0);
        }

        var num = new BigInteger();
        var remStackCount = remstack.Count;
        for (int i = 0; i < remStackCount; i++)
            num +=(remstack.Pop() * BigInteger.Pow(nBase, i));

        return num.ToString();
    }
}