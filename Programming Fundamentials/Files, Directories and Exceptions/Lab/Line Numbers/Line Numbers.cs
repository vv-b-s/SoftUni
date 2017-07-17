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
        var lines = File.ReadAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Line Numbers\Input.txt");

        for (int i = 0; i < lines.Length; i ++)
            lines[i] = $"{i + 1}. {lines[i]}";

        File.WriteAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Line Numbers\output.txt", lines);
    }
}