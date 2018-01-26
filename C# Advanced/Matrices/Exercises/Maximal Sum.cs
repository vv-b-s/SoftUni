using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class MaximalSum
{
    public static void Main(string[] args)
    {
        var mparams = ReadLine().Split(' ').Select(int.Parse).ToArray();
        var matrix = GetMatrix(mparams[0], mparams[1]);

        var submatrix = new long[3, 3];
        var submatrixSum = 0L;
        for(int i = 0;i<matrix.GetLength(0)-2;i++)
        {
            for(int j = 0;j<matrix.GetLength(1)-2;j++)
            {
                var tempSubmatrix = GetSubmatrix(matrix, i, j);
                var sum = 0L;
                foreach (var element in tempSubmatrix)
                    sum += element;

                if(sum>submatrixSum)
                {
                    submatrixSum = sum;
                    submatrix = tempSubmatrix;
                }
            }
        }

        WriteLine($"Sum = {submatrixSum}");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                Write(submatrix[i, j] + " ");
            WriteLine();
        }
    }

    /// <summary>
    /// Get the submatrix filled with 3x3 part of the original one
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="submarrix"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private static long[,] GetSubmatrix(long[,] matrix, int row, int col)
    {
        var submatrix = new long[3, 3];
        for(int i = row, i_sub = 0; i_sub < 3; i++, i_sub++)
        {
            for(int j = col, j_sub = 0; j_sub<3; j++,j_sub++)
            {
                submatrix[i_sub, j_sub] = matrix[i, j];
            }
        }

        return submatrix;
    }

    /// <summary>
    /// Use the Console.ReadLine() method to read the matrix elements
    /// </summary>
    /// <param name="height"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    private static long[,] GetMatrix(int height, int width)
    {
        var matrix = new long[height, width];

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            var array = ReadLine().Split(' ').Where(n => n != "").Select(long.Parse).ToArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = array[j];
        }

        return matrix;
    }
}

