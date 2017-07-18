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
        var input1 = File.ReadAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Merge Files\Input1.txt")
            .Split('\r','\n')
            .Where(w=>w!="")
            .ToList();

        var input2 = File.ReadAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Merge Files\Input2.txt")
            .Split('\r', '\n')
            .Where(w => w != "")
            .ToList();

        var output = input1.Concat(input2).OrderBy(i=>i).ToList();

        File.WriteAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Lab\Merge Files\Output.txt", output);
    }
}