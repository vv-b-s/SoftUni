using System;
using System.Linq;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        long[] array = Array.ConvertAll(ReadLine().Split(' '),long.Parse);

        WriteLine(Condense(array));
    }

    static long Condense(long[] arr)
    {
        if (arr.Length == 1)
            return arr[0];

        long[] temp = new long[arr.Length-1];
        for (int i = 0; i < temp.Length; i++)
            temp[i] = arr[i] + arr[i + 1];
        arr = temp;
        long condensedNum = Condense(arr);

        return condensedNum;
    }
}
