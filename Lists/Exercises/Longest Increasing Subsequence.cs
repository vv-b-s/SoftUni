using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var rawList = CleanArray(ReadLine().Trim().Split()).Select(int.Parse).ToList();

        int[] LIS = FindLongestIncreasingSubsequence(rawList.ToArray());
        WriteLine(string.Join(" ", LIS));
    }

    public static int[] FindLongestIncreasingSubsequence(int[] sequence)
    {
        int[] length = new int[sequence.Length];
        int[] prev = new int[sequence.Length];
        int maxLength = 0;
        int lastIndex = -1;

        for (int i = 0; i < sequence.Length; i++)
        {
            length[i] = 1;
            prev[i] = -1;

            for (int j = 0; j < i; j++)
            {
                if (sequence[j] < sequence[i] && length[j] >= length[i])
                {
                    length[i] = 1 + length[j];
                    prev[i] = j;
                }
            }

            if (length[i] > maxLength)
            {
                maxLength = length[i];
                lastIndex = i;
            }
        }

        var longestSeq = new List<int>();
        for (int i = 0; i < maxLength; i++)
        {
            longestSeq.Add(sequence[lastIndex]);
            lastIndex = prev[lastIndex];
        }

        longestSeq.Reverse();
        return longestSeq.ToArray();
    }

    static string[] CleanArray(string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        return raw.ToArray();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}