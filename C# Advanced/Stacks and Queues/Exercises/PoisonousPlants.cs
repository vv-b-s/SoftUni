using System;
using System.Collections.Generic;
using System.Linq;

//Solution by RAstardzhiev
public class PoisonousPlants
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var plants = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Take(n)
            .ToArray();

        var days = new int[n];

        //The stack is used to keep track of the maximum days the plants will live by their index
        var indexes = new Stack<int>();
        indexes.Push(0);

        for (int i = 1; i < plants.Length; i++)
        {
            int maxDays = 0;

            //While the indexes stack is not empty and the plant at the top is greater than the current one
            while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
            {
                //the max days will be increased if they are lower than their previous value and the index will be removed from the stack
                maxDays = Math.Max(maxDays, days[indexes.Pop()]);
            }

            // to eventually be replaced with new value of max days or start from 0 again
            if (indexes.Count > 0)
            {
                days[i] = maxDays + 1;
            }

            indexes.Push(i);
        }

        Console.WriteLine(days.Max());
    }
}
