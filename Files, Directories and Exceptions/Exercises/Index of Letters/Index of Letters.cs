using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;

class Program
{
    static void Main()
    {
        var text = File.ReadAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Index of Letters\input.txt");
        var output = new StringBuilder();

        foreach (var ch in text)
            output.AppendLine($"{ch} -> {ch-97}");
        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Index of Letters\output.txt", output.ToString());
    }
}