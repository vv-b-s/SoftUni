using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class SquaresInMatrix
{
    public static void Main(string[] args)
    {
        var matrixSize = ReadLine().Split(' ').Select(int.Parse).ToArray() ;

        var matrix = new string[matrixSize[0]][];
        for (int i = 0; i < matrixSize[0]; i++)
            matrix[i] = ReadLine().Split(' ').Where(n => n != "").ToArray();

        var numberOfSquares = 0;
        for (int i = 0; i < matrix.Length - 1; i++)
            for (int j = 0; j < matrix[i].Length - 1; j++)
                if (matrix[i][j] == matrix[i][j + 1] && matrix[i + 1][j] == matrix[i][j] && matrix[i + 1][j + 1] == matrix[i][j])
                    numberOfSquares++;
        WriteLine(numberOfSquares);
    }
}

