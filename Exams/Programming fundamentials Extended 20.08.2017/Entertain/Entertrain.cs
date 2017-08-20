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
        int locomotivePower = int.Parse(ReadLine());

        List<int> wagons = new List<int>();

        string input;
        while((input=ReadLine())!= "All ofboard!")
        {
            wagons.Add(int.Parse(input));
            if(wagons.Sum()>locomotivePower)
            {
                double wagonsAverage = wagons.Average();
                var sortedWagons = wagons.ToArray();
                Array.Sort(sortedWagons);
                int[] elementsToRemove =
                {
                    sortedWagons.First(w=>w<wagonsAverage),
                    sortedWagons.First(w=>w>wagonsAverage)
                };
                int elementToRemove = wagonsAverage - elementsToRemove[0] > elementsToRemove[1] - wagonsAverage ?
                    elementsToRemove[1] : elementsToRemove[0];
        
                wagons.Remove(elementToRemove);
            }
        }
        wagons.Reverse();
        wagons.Add(locomotivePower);
        WriteLine(string.Join(" ", wagons));
    }
}
