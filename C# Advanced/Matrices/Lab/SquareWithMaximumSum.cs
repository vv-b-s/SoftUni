using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class SquareWithMaximumSum
{
    public static void Main(string[] args)
    {
        var matrixParameters = ReadArray();

        int rows = (int)matrixParameters[0];
        int cols = (int)matrixParameters[1];

        var matrix = new double[rows, cols];

        for(int row = 0;row<rows;row++)
        {
            var rowElements = ReadArray();
            for (int col = 0; col < cols; col++)
                matrix[row,col] = rowElements[col];
        }

        var subMatrix = new double[2, 2];
        var submatrixSum = double.MinValue;
        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                var sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (sum > submatrixSum)
                {
                    submatrixSum = sum;
                    subMatrix[0, 0] = matrix[row, col];
                    subMatrix[0, 1] = matrix[row, col + 1];
                    subMatrix[1, 0] = matrix[row + 1, col];
                    subMatrix[1, 1] = matrix[row + 1, col + 1];
                }
            }
        }

        for(int i=0;i<2;i++)
        {
            for (int j = 0; j < 2; j++)
                Write(subMatrix[i, j] + " ");
            WriteLine();
        }
        WriteLine(submatrixSum);
    }

    private static double[] ReadArray() => ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
}