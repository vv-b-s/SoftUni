using System;
using System.Linq;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string arrayInString = ReadLine();
        long[] array = Array.ConvertAll(arrayInString.Split(' '), long.Parse);

        bool pairsExist = false;
        for(int i=0;i<array.Length-1;i++)
            for (int j = i+1; j < array.Length; j++)
            {
                if (array.Contains(array[i] + array[j]))
                {
                    WriteLine($"{array[i]} + {array[j]} == {array[i]+array[j]}");
                    pairsExist = true;
                }
            }
        if(!pairsExist)
            WriteLine("No");
    }

}
