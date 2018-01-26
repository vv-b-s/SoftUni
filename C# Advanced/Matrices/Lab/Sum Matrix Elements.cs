using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class SumMatrixElements
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

        var matrixSum = 0.0;
        foreach (var element in matrix)
            matrixSum += element;

        WriteLine(rows);
        WriteLine(cols);
        WriteLine(matrixSum);
    }

    private static double[] ReadArray() => ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
}

