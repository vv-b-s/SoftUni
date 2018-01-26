using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class TargetPractice
{
    //Use this to keep the inpact positions for every row.
    private static HashSet<int> impactPositions;

    //Use queue for easier rotation
    private static Queue<char> snake;

    private static char[,] stairs;

    public static void Main(string[] args)
    {
        //Collect user data
        var mParam = ReadLine().Split(' ').Select(int.Parse).ToArray();

        stairs = new char[mParam[0], mParam[1]];

        snake = new Queue<char>(ReadLine().ToCharArray());

        var gunData = ReadLine().Split(' ').Where(gp => gp != "").Select(int.Parse).ToArray();
        var shotRow = gunData[0];
        var shotCol = gunData[1];
        var impact = gunData[2];

        var lowerImpact = shotRow + impact;
        var upperImpact = shotRow - impact;

        impactPositions = new HashSet<int>();
        //Filling the stairs with a snake

        //decide the direction of the snake
        var rtl = false;

        for (int i = mParam[0] - 1; i >= 0; i--)
        {
            //check if there was an inpact
            var isImpactRow = i <= lowerImpact && i >= upperImpact;
            if (isImpactRow)
                GetImpactPositions(i,shotCol,shotRow,impact);
            

            if (rtl)
            {
                for (int j = 0; j < mParam[1]; j++)
                {
                    PutSnake(i, j, isImpactRow);
                    rtl = false;
                }
            }
            else
            {
                for (int j = mParam[1] - 1; j >= 0; j--)
                {
                    PutSnake(i, j, isImpactRow);
                    rtl = true;
                }
            }

            impactPositions.Clear();
        }

        //Align the array by transponsing it
        for (int j = 0; j < stairs.GetLength(1); j++)
        {
            int[] knownEmptySpace = null;
            for (int i = stairs.GetLength(0) - 1; i >= 0; i--)
            {
                if (stairs[i, j] == ' ' && knownEmptySpace == null)
                    knownEmptySpace = new int[] { i, j };
                else if (knownEmptySpace != null && stairs[i, j] != ' ')
                {
                    stairs[knownEmptySpace[0], knownEmptySpace[1]] = stairs[i, j];
                    stairs[i, j] = ' ';
                    knownEmptySpace[0]--;
                }
            }
        }

        //Print the array
        var sB = new StringBuilder();
        for (int i = 0; i < stairs.GetLength(0); i++)
        {
            for (int j = 0; j < stairs.GetLength(1); j++)
                sB.Append(stairs[i, j]);
            sB.AppendLine();
        }

        Write(sB.ToString());
    }

    private static void PutSnake(int i, int j, bool isImpactRow)
    {
        if (isImpactRow && impactPositions.Contains(j))
        {
            snake.Enqueue(snake.Dequeue());
            stairs[i, j] = ' ';
        }
        else
        {
            var letter = snake.Dequeue();
            stairs[i, j] = letter;
            snake.Enqueue(letter);
        }
    }

    /// <summary>
    /// Fill the impact positions HashSet with the related positions
    /// </summary>
    /// <param name="shotCol"></param>
    /// <param name="curentImpact"></param>
    private static void GetImpactPositions(int i, int shotCol, int shotRow, int impact)
    {
        var deltaRow = i - shotRow;
        for (int j = 0; j < stairs.GetLength(1); j++)
        {
            var deltaCol = j - shotCol;
            if (Math.Pow(deltaRow, 2) + Math.Pow(deltaCol, 2) <= Math.Pow(impact, 2))
                impactPositions.Add(j);
        }
    }
}