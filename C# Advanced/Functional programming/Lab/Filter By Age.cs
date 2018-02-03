using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class FilterByAge
{
    public static void Main(string[] args)
    {
        var numberOfPeople = int.Parse(ReadLine());
        var inputLines = new Queue<string>();

        for (int i = 0; i < numberOfPeople; i++)
            inputLines.Enqueue(ReadLine());

        var people = GetDictionaryData(inputLines, line =>
        {
            var lineData = line.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return new KeyValuePair<string, int>(lineData[0], int.Parse(lineData[1]));
        });

        var condition = ReadLine();
        var ageToFilter = int.Parse(ReadLine());
        var dataToDisplay = ReadLine();

        var filteredPeople = SelectData(people, person => condition == "older" ? person.Value >= ageToFilter : person.Value < ageToFilter);

        PrintFilteredData(filteredPeople, person =>
        {
             if (dataToDisplay == "name")
                 return person.Key;
             if (dataToDisplay == "age")
                 return person.Value.ToString();
             else
                 return $"{person.Key} - {person.Value}";
        });
    }

    /// <summary>
    /// Gets a set of lines and feeds a dictionary of them
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="inputLines"></param>
    /// <param name="relationLogic"></param>
    /// <returns></returns>
    private static Dictionary<TKey, TValue> GetDictionaryData<TKey, TValue>(Queue<string> inputLines, Func<string, KeyValuePair<TKey, TValue>> relationLogic)
    {
        var outputDictionary = new Dictionary<TKey, TValue>();

        while (inputLines.Count>0)
        {
            var pair = relationLogic(inputLines.Dequeue());
            outputDictionary[pair.Key] = pair.Value;
        }

        return outputDictionary;
    }

    /// <summary>
    /// Filters the data as desired
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    private static Queue<KeyValuePair<TKey, TValue>> SelectData<TKey, TValue>(Dictionary<TKey, TValue> dictionary, Func<KeyValuePair<TKey, TValue>,bool> filter)
    {
        var outputQueue = new Queue<KeyValuePair<TKey, TValue>>();

        foreach (var item in dictionary)
        {
            if (filter(item))
                outputQueue.Enqueue(item);
        }

        return outputQueue;
    }

    /// <summary>
    /// Prints the data as required
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dataToOutput"></param>
    /// <param name="itemsToShow"></param>
    private static void PrintFilteredData<TKey, TValue>(Queue<KeyValuePair<TKey, TValue>> dataToOutput, Func<KeyValuePair<TKey, TValue>, string> itemsToShow)
    {
        var sB = new StringBuilder();

        while (dataToOutput.Count > 0)
            sB.AppendLine(itemsToShow(dataToOutput.Dequeue()));

        Write(sB.ToString());
    }
}