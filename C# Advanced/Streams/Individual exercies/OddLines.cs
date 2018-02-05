using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

class OddLines
{
    public static void Main(string[] args)
    {
        Write("Enter file path: ");
        var path = ReadLine();

        using (var textFile = new StreamReader(path))
        {
            var lines = textFile.ReadToEnd().Split(Environment.NewLine);
            var oddLines = new StringBuilder();

            for (int i = 1; i < lines.Length; i += 2)
                oddLines.AppendLine(lines[i]);

            Write(oddLines.ToString());
        }
    }
}