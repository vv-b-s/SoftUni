using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var sequence = ReadLine().Split().Select(int.Parse).ToList();
        var stepsTaken = 0;
        for(int i=0;i<sequence.Count;i++)
        {
            stepsTaken++;
            if(sequence[i]!=0)
            {
                var teleportTo = sequence[i];
                sequence[i] = 0;
                i = teleportTo;
            }
        }
        WriteLine(stepsTaken);
    }
}
