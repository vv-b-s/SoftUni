using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var rawList = CleanArray(ReadLine().Trim().Split()).Select(long.Parse).ToList();

        while(true)
        {
            string[] userInput = ReadLine().Split();
            string command = userInput[0];

            switch(command)
            {
                case "add":
                    int index = int.Parse(userInput[1]);
                    long element = long.Parse(userInput[2]);
                    rawList = AddItemToList(rawList, index, element);
                    break;
                case "addMany":
                    index = int.Parse(userInput[1]);
                    var elements = new List<long>();

                    for (int j = 2; j<userInput.Length; j++)
                        elements.Add( long.Parse(userInput[j]));
                    rawList = AddItemsToList(rawList, index, elements);
                    break;
                case "contains":
                    element = long.Parse(userInput[1]);
                    WriteLine(rawList.Contains(element) ?
                        rawList.IndexOf(element) : -1);
                    break;
                case "remove":
                    index = int.Parse(userInput[1]);
                    rawList.RemoveAt(index);
                    break;
                case "shift":
                    int positions = int.Parse(userInput[1]);
                    rawList = ShiftList(rawList, positions);
                    break;
                case "sumPairs":
                    SumListPairs(rawList);
                    break;
                case "print":
                    WriteLine("[" + string.Join(", ", rawList) + "]");
                    return;
            }
        }
    }

    static List<long> AddItemToList(List<long> list, int index, long element)
    {
        if (index > list.Count - 1)
        {
            list.Add(element);
            return list;
        }
        var tempList = new List<long>();
        for(int i=0;i<list.Count;i++)
        {
            if (i < index || i > index|| index > list.Count-1)
                tempList.Add(list[i]);
            else
            {
                tempList.Add(element);
                tempList.Add(list[i]);
            }
        }

        return tempList;
    }

    static List<long> AddItemsToList(List<long> list, int index, List<long> elements)
    {
        if (index > list.Count - 1)
        {
            foreach (var item in elements)
            {
                list.Add(item);
            }
            return list;
        }
        List<long> tempList = new List<long>();
        for(int i=0;i<list.Count;i++)
        {
            if (i < index || i > index||index>list.Count-1)
                tempList.Add(list[i]);
            else
            {
                foreach (var item in elements)
                    tempList.Add(item);
                tempList.Add(list[i]);
            }
        }

        return tempList;
    }

    static List<long> ShiftList(List<long> list, int pos)
    {
        for(int i=0;i<pos;i++)
        {
            long temp = list[0];
            list.RemoveAt(0);
            list = AddItemToList(list, list.Count, temp);
        }
        return list;
    }

    static void SumListPairs(List<long> list)
    {
        for(int i=0;i<list.Count;i+=2)
        {
            if (i == list.Count - 1)
                break;
            list[i] += list[i + 1];
        }
        for (int i = 0; i < list.Count; i += 2)
        {
            if (i == list.Count - 1)
                break;
            list.RemoveAt(i + 1);
            i--;
        }
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