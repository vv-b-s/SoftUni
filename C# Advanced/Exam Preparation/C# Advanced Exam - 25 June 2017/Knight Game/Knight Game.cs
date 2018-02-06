using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    //Use those positions to define where the Knights might strike
    private static int[][] deltas = new int[][]
        {
            new[]{ -2,-1 },
            new[]{ -2, 1 },
            new[]{ -1, -2 },
            new[]{ -1, 2 },
            new[]{ 1,-2},
            new[]{ 1,2},
            new[]{ 2,-1},
            new[]{ 2,1}
        };
    public static void Main(string[] args)
    {
        var inputLength = int.Parse(ReadLine());

        var board = new char[inputLength][];

        for (int i = 0; i < inputLength; i++)
            board[i] = ReadLine().ToCharArray();

        var numberOfRemovedKnights = 0;
        var allKnightsAreSafe = false;
        while(!allKnightsAreSafe)
        {
            allKnightsAreSafe = true;
            var strongestKnightPosition = new int[2];
            var strongestKnightStrength = 0;

            for (int i = 0;i<board.Length;i++)
            {
                for(int j = 0;j<board.Length;j++)
                {
                    if(board[i][j]=='K'&&!KnightIsSafe(i,j,board,out int numberOfAttacks))
                    {
                        if(numberOfAttacks>strongestKnightStrength)
                        {
                            strongestKnightPosition[0] = i;
                            strongestKnightPosition[1] = j;

                            strongestKnightStrength = numberOfAttacks;
                            allKnightsAreSafe = false;
                        }
                    }
                }
            }

            if(!allKnightsAreSafe)
            {
                board[strongestKnightPosition[0]][strongestKnightPosition[1]] = '0';
                numberOfRemovedKnights++;
            }
        }

        WriteLine(numberOfRemovedKnights);
    }

    private static bool KnightIsSafe(int i, int j, char[][] board, out int numberOfAttacksMade)
    {
        int x, y;
        numberOfAttacksMade = 0;

        foreach (var delta in deltas)
        {
            for (int r = 0; r < deltas.GetLength(0); r++)
            {

                //Get the potentional position the knight can move to
                x = i + delta[0];
                y = j + delta[1];

                //Check if the position is in the board
                if (x < board.Length && x >= 0 && y < board[0].Length && y >= 0)
                {
                    //Check if there is a Knight on the new position
                    if (board[x][y] == 'K')
                        numberOfAttacksMade++;
                }

            }
        }


        return numberOfAttacksMade==0;
    }
}