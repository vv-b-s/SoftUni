using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

class WordCount
{
    public static void Main(string[] args)
    {
        //Get the required files
        Write("Enter the path of the text file: ");
        var textFilePath = new FileInfo(ReadLine());

        Write("Enter the path of the words file: ");
        var wordsFilePath = new FileInfo(ReadLine());

        //Get the searched words
        var wordsCount = new Dictionary<string, int>();
        using (var wordsFile = new StreamReader(wordsFilePath.FullName))
        {
            string word;
            while((word = wordsFile.ReadLine()) != null)
                wordsCount[word] = 0;
        }

        //Get the words from the file
        using (var textFile = new StreamReader(textFilePath.FullName))
        {
            //Split all the whitespaces
            var words = Regex.Split(textFile.ReadToEnd(), @"\b").Select(w=>w.ToLower());

            //Count the occurances
            foreach (var word in words)
            {
                if (wordsCount.ContainsKey(word.ToLower()))
                    wordsCount[word]++;
            }
        }

        //Sort the dictionary
        wordsCount = wordsCount.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, c => c.Value);

        //Write the result
        //Get result's directory
        var resultFilePath = new FileInfo(wordsFilePath.Directory + @"\" + "result.txt");

        //Write the file
        using (var resultFile = new StreamWriter(resultFilePath.FullName))
        {
            //Build the output string
            var sB = new StringBuilder();
            foreach (var word in wordsCount)
                sB.AppendLine($"{word.Key} - {word.Value}");

            //Write the string on the file
            resultFile.Write(sB.ToString());
        }

        WriteLine("Operation complete.");
    }
}