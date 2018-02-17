using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = ParseArray(Console.ReadLine());
            int height = dimestions[0];
            int width = dimestions[1];

            int[,] matrix = new int[height, width];

            int value = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    matrix[i, j] = value++;
            }

            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoS = ParseArray(command);
                int[] evil = ParseArray(Console.ReadLine());
                int xE = evil[0];
                int yE = evil[1];

                for (; xE >= 0 && yE >= 0; xE--, yE--) 
                {
                    if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                        matrix[xE, yE] = 0;
                    
                }

                int xI = ivoS[0];
                int yI = ivoS[1];

                for (; xI >= 0 && yI < matrix.GetLength(1);yI++,xI--)
                {
                    if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                        sum += matrix[xI, yI];
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        public static int[] ParseArray(string input) => input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }
}
