using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Console;

class Program
{
    static void Main()
    {
        string input = ReadLine();

        var numbers = input.Where(n => char.IsNumber(n)).Select(c => (int)char.GetNumericValue(c)).ToList();
        var takeList = new List<int>();
        var skipList = new List<int>();

        for(int i=0;i<numbers.Count;i++)
        {
            if (i % 2 == 0)
                takeList.Add(numbers[i]);
            else
                skipList.Add(numbers[i]);
        }

        input = new string(input.Where(c => !char.IsNumber(c)).ToArray());

        var newWord = new StringBuilder();
        var skipPrevious = 0;

        for(int i=0;i<takeList.Count;i++)
        {
            newWord.Append(new string(input.Skip(skipPrevious).Take(takeList[i]).ToArray()));
            skipPrevious += takeList[i] + skipList[i];
        }

        WriteLine(newWord.ToString());
    }
}