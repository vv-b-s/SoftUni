using System;
using System.Linq;

namespace Bubble_Sort_Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new int[] { 2, 6, 8, 4, 6, 9, 8, 2, 3, 66, 5 };

            Console.WriteLine(string.Join(" ", elements));

            elements = Bubble.Sort(elements).ToArray();

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
