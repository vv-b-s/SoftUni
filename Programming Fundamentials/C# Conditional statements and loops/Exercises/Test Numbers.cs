using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int numberN = int.Parse(ReadLine());
        int numberM = int.Parse(ReadLine());
        int maxSum = int.Parse(ReadLine());

        int sum = 0;
        int combinations = 0;
        for(int i = numberN;i>0;i--)
        {
            for (int j = 1; j <= numberM; j++)
            {
                sum += i * j * 3;
                combinations++;
                if (sum >= maxSum)
                    break;
            }
            if (sum >= maxSum)
                break;
        }

        WriteLine(sum >= maxSum ? $"{combinations} combinations\nSum: {sum} >= {maxSum}" : $"{combinations} combinations\nSum: {sum}");
    }
}
