using System;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        long[] array = Array.ConvertAll(ReadLine().Split(' '),long.Parse);

        int middleElementsSize = 1;
        if (array.Length > 1)
            middleElementsSize = array.Length % 2 == 0 ? 2 : 3;
        long[] middleArray = new long[middleElementsSize];

        if (middleArray.Length > 1)
        {
            if (middleArray.Length == 2)
            {
                middleArray[0] = array[array.Length / 2 - 1];
                middleArray[1] = array[array.Length / 2];
            }
            else
            {
                middleArray[0] = array[array.Length / 2 - 1];
                middleArray[1] = array[array.Length / 2];
                middleArray[2] = array[array.Length / 2 + 1];
            }
        }
        else
            middleArray[0] = array[0];

        PrintArrayFormated(middleArray);
    }

    static void PrintArrayFormated(long[] arr)
    {
        switch (arr.Length)
        {
                case 1:
                WriteLine($"{'{'} {arr[0]} {'}'}"); break;
                case 2:
                    WriteLine($"{'{'} {arr[0]}, {arr[1]} {'}'}"); break;
                case 3:
                    WriteLine($"{'{'} {arr[0]}, {arr[1]}, {arr[2]} {'}'}"); break;
        }
    }
}
