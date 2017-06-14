using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    public delegate int Sums(int a, int b);
    static void Main()
    {
        var rawList = CleanArray(ReadLine().Trim().Split()).Select(int.Parse).ToList();

        string userInput = ReadLine();
        while (!(userInput == "Odd" || userInput == "Even"))
        {
            string command = userInput.Split()[0];

            switch (command)
            {
                case "Delete":
                    int itemToBeRemoved = int.Parse(userInput.Split()[1]);
                    rawList.RemoveAll(t => t == itemToBeRemoved);
                    break;
                case "Insert":
                    int element = int.Parse(userInput.Split()[1]);
                    int position = int.Parse(userInput.Split()[2]);
                    rawList.Insert(position, element);
                    break;
            }

            userInput = ReadLine();
        }

        
        WriteLine(string.Join(" ", OddOrEven(rawList,userInput)));
    }

    static List<int> OddOrEven(List<int> rawList, string command)
    {
        var temp = new List<int>();
        switch(command)
        {
            case "Odd":
                foreach (var item in rawList)
                    if (item % 2 != 0)
                        temp.Add(item);
                break;
            case "Even":
                foreach (var item in rawList)
                    if (item % 2 == 0)
                        temp.Add(item);
                break;
        }
        return temp;
    }

    static int FindMaxValue(Dictionary<int,int> dict)
    {
        var maxValue = int.MinValue;
        foreach (var item in dict)
            maxValue = item.Value > maxValue ? item.Value : maxValue;
        return maxValue;
    }

    static string[] CleanArray(string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        return raw.ToArray();
    }
}