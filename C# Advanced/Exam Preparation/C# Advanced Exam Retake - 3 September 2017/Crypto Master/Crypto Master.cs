using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        var sequence = ReadLine().Split(", ".ToArray(),StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var longestLength = 0;

        for(int i = 0;i<sequence.Length;i++)
        {
            for(int step = 1;step<=sequence.Length;step++)
            {
                var previousNumber = sequence[i];
                var currentLength = 1;

                for (int j = (i + step) % sequence.Length; j != i; j = (j + step) % sequence.Length) 
                {
                    if (sequence[j] > previousNumber)
                    {
                        currentLength++;
                        previousNumber = sequence[j];
                    }
                    else
                        break;
                }

                if (longestLength < currentLength)
                    longestLength = currentLength;
            }
        }

        WriteLine(longestLength);
    }
}