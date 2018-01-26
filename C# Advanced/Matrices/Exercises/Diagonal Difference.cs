using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class DiagonalDifference
{
    public static void Main(string[] args)
    {
        var matrixSize = int.Parse(ReadLine());

        var matrix = new double[matrixSize][];
        for (int i = 0; i < matrixSize; i++)
            matrix[i] = ReadLine().Split(' ').Where(n => n != "").Select(double.Parse).ToArray();

        double firstDiagonalSum = 0;
        double secondDiagonalSum = 0;
        for (int i = 0, j=matrixSize-1; i < matrixSize; i++,j--)
        {
            firstDiagonalSum += matrix[i][i];
            secondDiagonalSum += matrix[i][j];
        }

        var diagonalDifference = Math.Abs(firstDiagonalSum - secondDiagonalSum);
        WriteLine(diagonalDifference);
    }
}

