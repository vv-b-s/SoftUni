using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
    static void Main()
    {
        var array = Array.ConvertAll(ReadLine().Split(), int.Parse);
        int exceptionCount = 0;

        while(exceptionCount<3)
        {
            try
            {
                string[] input = ReadLine().Split();

                var command = input[0];
                switch (command)
                {
                    case "Replace":
                        int index = int.Parse(input[1]);
                        int element = int.Parse(input[2]);
                        array[index] = element;
                        break;
                    case "Print":
                        int startIndex = int.Parse(input[1]);
                        int endIndex = int.Parse(input[2]);
                        if (endIndex >= array.Length)
                            throw new IndexOutOfRangeException();
                        for (int i = startIndex; i <= endIndex; i++)
                            Write(i == endIndex ? array[i].ToString()
                                : array[i] + ", ");
                        WriteLine();
                        break;
                    case "Show":
                        index = int.Parse(input[1]);
                        WriteLine(array[index]);
                        break;
                }
            }
            catch (IndexOutOfRangeException)
            {
                WriteLine("The index does not exist!");
                exceptionCount++;
            }
            catch(FormatException)
            {
                WriteLine("The variable is not in the correct format!");
                exceptionCount++;
            }
        }
        WriteLine(string.Join(", ", array));

    }
}