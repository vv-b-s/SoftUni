using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class MatrixOfPalindromes
{
    public static void Main(string[] args)
    {
        var matrixParemeters = ReadLine().Split(' ').Select(int.Parse).ToArray();
        var rows = matrixParemeters[0];
        var cols = matrixParemeters[1];

        var matrix = new char[rows, cols, 3];
        // initialize the first elements in the matrix
        for (int k = 0; k < 3; k++)
            matrix[0, 0, k] = 'a';

        for(int i = 0;i<matrix.GetLength(0);i++ )
        {
            //Assign the first element
            if(i!=0)
                for (int k = 0; k < 3; k++)
                    matrix[i, 0, k] = (char)(matrix[i - 1, 0, 0] + 1);

            //Assign all other elements according to the rules
            for (int j = 1; j < matrix.GetLength(1); j++) 
            {
                for (int k = 0; k < 3; k++) 
                {
                    //Only the middle element changes the most
                    if (k == 1)
                        matrix[i, j, k] = (char)(matrix[i, j - 1, k] + 1);
                    else matrix[i, j, k] = matrix[i, 0, 0];
                }
            }
        }

        //Print the array
        var sB = new StringBuilder();
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0;j<matrix.GetLength(1);j++)
            {
                for (int k = 0; k < 3; k++)
                    sB.Append(matrix[i, j, k]);
                sB.Append(' ');
            }
            sB.AppendLine();
        }

        Write(sB.ToString());
    }
}

