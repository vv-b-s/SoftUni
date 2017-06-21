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
        var lines = File.ReadAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Odd Lines\input.txt");

        var sB = new StringBuilder();
        for (int i = 1; i < lines.Length; i += 2)
            sB.AppendLine(lines[i]);

        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Odd Lines\output.txt", sB.ToString());
    }
}