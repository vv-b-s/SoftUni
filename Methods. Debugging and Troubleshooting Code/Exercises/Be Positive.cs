using System;
using System.Collections.Generic;

public class BePositive_broken
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());
        List<int>[] numbers = new List<int>[countSequences];

        for (int i = 0; i < countSequences; i++)
        {
            numbers[i] = new List<int>();
            string[] input = Console.ReadLine().Trim().Split(' ');

            for (int j = 0; j < input.Length; j++)
            {
                if (!input[j].Equals(string.Empty))
                {
                    int num = int.Parse(input[j]);
                    numbers[i].Add(num);
                }
            }

        }


        foreach (var list in numbers)
        {
            bool found = false;
            for (int j = 0; j < list.Count; j++)
            {
                int currentNum = list[j];

                if (currentNum >= 0)
                {
                    if (found)
                        Console.Write(" ");

                    Console.Write(currentNum);

                    found = true;
                }
                else if(j!=list.Count-1)
                {
                     currentNum += list[j + 1];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                        j++;
                    }
                    else
                        j++;
                }
                if (j == list.Count - 1)
                    CheckIfFound(found);
            }
        }
    }

    static void CheckIfFound(bool isFound)
    {
        if (isFound)
            Console.WriteLine();
        else
            Console.WriteLine("(empty)");
    }
}
