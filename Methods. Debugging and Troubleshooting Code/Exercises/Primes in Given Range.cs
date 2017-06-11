using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        List<int> primes = GetPrimesInRange((int)ReadNum(), (int)ReadNum());
        var sB = new StringBuilder();
        foreach (var item in primes)
            sB.Append(item + ", ");
        sB.Remove(sB.Length - 2, 2);
        WriteLine(sB);
    }

    public static List<int> GetPrimesInRange(int start,int end)
    {
        var primes = new List<int>();

        for(int i=start;i<=end;i++)
        {
            if (i == 1 || i == 0) continue;

            var boundary = (long)Math.Floor(Math.Sqrt(i));

            bool notAPrime = false;
            for (long j = 2; j <= boundary; ++j)
                if (i % j == 0)
                {
                    notAPrime = true;
                    break;
                }
            if (notAPrime)
                continue;

            primes.Add(i);
        }
        return primes;
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
