using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class LegoBlocks
{
    public static void Main(string[] args)
    {
        var numberOfLines = int.Parse(ReadLine());

        var pieceOne = new int[numberOfLines][];
        var pieceTwo = new int[numberOfLines][];

        var totalCellNumber = 0;
        
        //Fill in the first piece
        for(int i = 0; i < numberOfLines; i++)
        {
            pieceOne[i] = ReadArray();
            totalCellNumber += pieceOne[i].Length;
        }

        //Fill in the second piece
        for(int i = 0; i < numberOfLines; i++)
        {
            pieceTwo[i] = ReadArray();
            totalCellNumber += pieceTwo[i].Length;
        }

        //Decide if pieces match
        int arrayWidth;
        if (PiecesMatch(pieceOne, pieceTwo, out arrayWidth))
        {
            var sB = new StringBuilder();
            for (int i = 0; i < numberOfLines; i++)
            {
                sB.Append("[");
                for (int j = 0, k = pieceTwo[i].Length-1 ; j < arrayWidth; j++)
                {
                    if (j <= pieceOne[i].Length - 1)
                    {
                        sB.Append($"{pieceOne[i][j]}, ");
                    }
                    else if (j >= pieceOne[i].Length)
                    {
                        if (j < arrayWidth - 1)
                            sB.Append($"{pieceTwo[i][k]}, ");
                        else
                            sB.Append($"{pieceTwo[i][k]}]\n");
                        k--;
                    }
                }
            }

            WriteLine(sB.ToString());
        }
        else WriteLine($"The total number of cells is: {totalCellNumber}");
    }

    /// <summary>
    /// Measures if the outcome array will be rectangular
    /// </summary>
    /// <param name="pieceOne"></param>
    /// <param name="pieceTwo"></param>
    /// <param name="arrayWidth"></param>
    /// <returns></returns>
    private static bool PiecesMatch(int[][] pieceOne, int[][] pieceTwo, out int arrayWidth)
    {
        arrayWidth = pieceOne[0].Length + pieceTwo[0].Length;
        for(int i = 1; i < pieceOne.Length; i++)
        {
            var curentWidth = pieceOne[i].Length + pieceTwo[i].Length;
            if (curentWidth != arrayWidth)
                return false;
        }

        return true;
    }

    private static int[] ReadArray() => ReadLine().Split(' ').Where(n => n != "").Select(int.Parse).ToArray();
}