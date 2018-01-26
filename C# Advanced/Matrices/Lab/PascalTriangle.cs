using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class PascalTriangle
{
    public static void Main(string[] args)
    {
        var triangleSize = int.Parse(ReadLine());

        var triangleMatrix = new long[triangleSize][];
        for(int i = 0; i < triangleSize; i++)
        {
            //First and second rows should be assigned first
            if(i==0)
                triangleMatrix[i] = new long[]{ 1};
            else if (i == 1)
                triangleMatrix[i] = new long[] { 1, 1 };
            else
            {
                //Assign matrix length
                triangleMatrix[i] = new long[i + 1];

                //The first element should always be 1
                triangleMatrix[i][0] = 1;

                //Every other element should be the sum of the previous left and right elements

                //Add elements to the middle of the matrix
                for (int j = 1; j <= triangleMatrix[i].Length / 2; j++)
                    triangleMatrix[i][j] = triangleMatrix[i - 1][j - 1] + triangleMatrix[i - 1][j];

                //Add the elements of the last part which are a mirror to the previous elements
                // j will start from the last element and will be equal to the first j-1 will be equal to the second and so on
                // k is the index j should be equal to
                for (int j = triangleMatrix[i].Length - 1, k = 0; j > triangleMatrix[i].Length / 2; j--, k++)
                    triangleMatrix[i][j] = triangleMatrix[i][k];
            }
        }

        //Print the array
        var sB = new StringBuilder();
        for (int i = 0; i < triangleSize; i++)
            sB.AppendLine(string.Join(" ", triangleMatrix[i]));

        Write(sB.ToString());
    }
}

