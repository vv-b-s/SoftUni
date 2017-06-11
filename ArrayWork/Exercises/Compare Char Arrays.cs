using System;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Numerics;
using static System.Console;

class Program
{
    static void Main()
    {
        char[][] arrays = new char[2][];
        arrays[0] = Array.ConvertAll(ReadLine().Split(' '), char.Parse);
        arrays[1] = Array.ConvertAll(ReadLine().Split(' '), char.Parse);

        int smallestCharLength = arrays[0].Length < arrays[1].Length ? arrays[0].Length : arrays[1].Length;
        int theFirstArray = 0;

        for(int i =0;i<smallestCharLength;i++)
        {
            if (arrays[0][i] == arrays[1][i]&&i!=smallestCharLength-1)
                continue;
            else if(arrays[0][i]<arrays[1][i])
            {
                theFirstArray = 0;
                break;
            }
            else if(i==smallestCharLength-1&& arrays[0][i] == arrays[1][i])
            {
                theFirstArray = arrays[0].Length < arrays[1].Length ? 0 : 1;
                break;
            }
            else
            {
                theFirstArray = 1;
                break;
            }
        }

        WriteLine(theFirstArray == 0 ?
            $"{PrintArray(arrays[0], "")}\n" +
            $"{PrintArray(arrays[1], "")}" :
           $"{PrintArray(arrays[1], "")}\n" +
            $"{PrintArray(arrays[0], "")}");
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        foreach (var a in arr)
            sB.Append($"{a}{format}");
        return sB.ToString();
    }
}
