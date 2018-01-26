using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class Crossfire
{
    public static void Main(string[] args)
    {
        var sizes = ReadLine().Split(' ').Select(long.Parse).ToArray();

        var matrix = new List<List<long>>();

        //Add the numbers to the matrix
        for (int i = 0, number = 1; i < sizes[0]; i++)
        {
            matrix.Add(new List<long>());
            for (int j = 0; j < sizes[1]; j++, number++)
                matrix[i].Add(number);
        }

        //Start nuking the matrix
        string input;
        while ((input = ReadLine()) != "Nuke it from orbit")
        {
            var shootParameters = input.Split(' ').Where(sp => sp != "").Select(long.Parse).ToArray();
            var shootPos = new long[] { shootParameters[0], shootParameters[1] };
            var shootRadius = shootParameters[2];

            //Define the boundaries of the horizontal shoot
            var horizontalShots = new long[] { shootPos[1] - shootRadius, shootPos[1] + shootRadius };

            //define the boundaries of the vertical shot
            var verticalShots = new long[] { shootPos[0] - shootRadius, shootPos[0] + shootRadius };

            //Destroy rows and cols
            for(int i = 0; i < matrix.Count; i++)
            {
                for(int j=0;j<matrix[i].Count;j++)
                {
                    //If the row is in the direction of the shot and the row is not in the direction of the shot and the column is in the field of the shot
                    if (j == shootPos[1] && i != shootPos[0] && i >= verticalShots[0] && i <= verticalShots[1])
                    {
                        matrix[i].RemoveAt(j);
                        break;
                    }
                    //Otherwise if the row is in the shot direction and the col is in the shot range
                    else if (i == shootPos[0] && j >= horizontalShots[0] && j <= horizontalShots[1])
                    {
                        var elementsToRemove = shootRadius * 2 + 1;
                        // if the shoot range is outside the borders form the left
                        if (horizontalShots[1] >= j && horizontalShots[0] < 0) 
                            elementsToRemove = horizontalShots[1]+1;
                        //if the shoot range is outside the border from the right
                        else if (horizontalShots[1] >= matrix[i].Count)
                            elementsToRemove = matrix[i].Count - j;

                        //If none of the previous conditions match the removing will stop when there are no elements to remove at the index
                        while (elementsToRemove-- > 0 && matrix[i].Count > j)   
                            matrix[i].RemoveAt(j);
                        break;
                    }
                }
            }

            //Shrink matrix
            matrix.RemoveAll(a => a.Count == 0);
        }

        //Print remaining elements
        foreach (var row in matrix)
            WriteLine(string.Join(" ", row));
    }
}