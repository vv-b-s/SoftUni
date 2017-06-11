using System;
using static System.Console;

class Program
{
    static void Main()
    {
        char[] nuc = { 'A', 'C', 'G', 'T' };
        int num = int.Parse(ReadLine());
        int newLine = 0;

        for(int i=0;i<nuc.Length;i++)
        {
            for (int j = 0;j<nuc.Length;j++)
                for(int k=0;k<nuc.Length;k++)
                {
                    char specialChar = i + j + k + 3 >= num ? 'O' : 'X';
                    Write($"{specialChar}{nuc[i]}{nuc[j]}{nuc[k]}{specialChar} ");
                    newLine++;
                    if(newLine==4)
                    {
                        WriteLine();
                        newLine = 0;
                    }
                }
        }
    }
}
