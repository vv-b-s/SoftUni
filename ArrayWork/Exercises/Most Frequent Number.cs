using System;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Numerics;
using static System.Console;

class Program
{
    static void Main()
    {
        int[] arr = Array.ConvertAll(ReadLine().Split(' '), int.Parse);

        int timesRepeated = 0, bestTimesRepeated = timesRepeated;

        int[] sortedArr = new int[arr.Length];
        for (int i = 0; i < sortedArr.Length; i++)
            sortedArr[i] = arr[i];

        Array.Sort(sortedArr);
        int repeatedNum = sortedArr[0], mostRepeatedNum = repeatedNum;

        for (int i = 1;i<sortedArr.Length;i++)
        {
            if (sortedArr[i-1]==sortedArr[i])
            {
                timesRepeated++;
                repeatedNum = sortedArr[i];
            }
            else if (sortedArr[i] != repeatedNum && timesRepeated > bestTimesRepeated)
            {
                bestTimesRepeated = timesRepeated;
                timesRepeated = 0;
                mostRepeatedNum = repeatedNum;
            }
            else
                timesRepeated = 0;
        }
        if (timesRepeated > bestTimesRepeated)
        {
            bestTimesRepeated = timesRepeated;
            mostRepeatedNum = repeatedNum;
        }
        bestTimesRepeated++;

        for(int i = 0;i<arr.Length;i++)
        {
            int rep = 0;
            int mostRep = arr[i];
            for(int j = 0;j<sortedArr.Length;j++)
            {
                if (arr[i] == sortedArr[j])
                    rep++;
            }
            if (rep == bestTimesRepeated)
            {
                mostRepeatedNum = arr[i];
                break;
            }
        }

        WriteLine(mostRepeatedNum);
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        foreach (var a in arr)
            sB.Append($"{a}{format}");
        return sB.ToString();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
