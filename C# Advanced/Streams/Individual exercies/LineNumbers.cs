using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

class LineNumbers
{
    public static void Main(string[] args)
    {
        Write("Enter file path: ");
        var file = new FileInfo(ReadLine());
        var outputFile = new FileInfo(file.Directory + "\\" + "output.txt");

        using (var textFile = new StreamReader(file.FullName))
        {
            var lines = textFile.ReadToEnd().Split(Environment.NewLine);

            var outputLines = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                var lineNumber = i + 1;
                outputLines.AppendLine($"Line {lineNumber}: {lines[i]}");
            }

            using (var outFile = new StreamWriter(outputFile.FullName))
                outFile.Write(outputLines.ToString());

            WriteLine("Operation complete.");
        }
    }
}