using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class Program
{
    private static char[][] floor;

    public static void Main(string[] args)
    {
        floor = new char[8][];

        for (int i = 0; i < floor.Length; i++)
            floor[i] = ReadLine().Split(',').Select(c => c[0]).ToArray();
        

        string move;
        while ((move = ReadLine()) != "END")
        {
            var figure = move[0];

            var startX = (int)char.GetNumericValue(move[1]);
            var startY = (int)char.GetNumericValue(move[2]);

            var endX = (int)char.GetNumericValue(move[4]);
            var endY = (int)char.GetNumericValue(move[5]);

            if (FigureIsValid(startX, startY, figure))
            {
                if (endX <= 7 && endY <= 7 && CanMove(startX, startY, endX, endY, figure)) 
                {
                    //Otherwise move the figure to its new position
                    floor[startX][startY] = 'x';
                    floor[endX][endY] = figure;
                }
                else if(endX>7||endY>7)
                    WriteLine("Move go out of board!");

                else WriteLine("Invalid move!");
            }
            else WriteLine("There is no such a piece!");
        }
    }

    private static bool FigureIsValid(int x, int y, char figure)
    {
        //If the place is outside the board
        if (x < 0 || x > 7 || y < 0 || y > 7)
            return false;

        //If the figure exists in this location
        if (floor[x][y] == figure)
            return true;

        return false;
    }

    private static bool CanMove(int startX, int startY, int endX, int endY, char figure)
    {
        //Get the distance to the desired place
        var distance = Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startY - endY, 2));

        var moveIsVertical = startY == endY;
        var moveIsDiagonal = false;

        //If the distance is not divisible by one it is probably diagonal or impossible move
        if(distance%1!=0)
        {
            //Check if the move is diagonal
            var horizontalDistance = Math.Abs(startX - endX);
            var verticalDistance = Math.Abs(startY - endY);

            //if the difference between the horizontal and vertical distances are equal to 0 the movement is diagonal
            if (horizontalDistance - verticalDistance == 0)
            {
                moveIsDiagonal = true;
                distance = horizontalDistance;
            }

            //Otherwise it is probably invalid move
            else return false;
        }

        //Check if the figure can move to that place

        //Kings and pawns can make only one move so if it is more than that it is invalid
        if ((figure == 'K' || figure == 'P') && distance > 1)
            return false;

        //Rooks and Pawns cannot move in a diagonal direction
        if ((figure == 'R' || figure == 'P') && moveIsDiagonal)
            return false;

        //Bishops can move only diagonally
        if (figure == 'B' && !moveIsDiagonal)
            return false;

        //Pawns cannot move backwards
        if (figure == 'P' && (endX>startX||endY!=startY))
            return false;

        //find out if there is something on the way of the figure

        //Define which is the highest and lowest position
        var highestPoints = new int[] { Math.Max(startX, endX), Math.Max(startY, endY) };
        var lowestPoints = new int[] { Math.Min(startX, endX), Math.Min(startY, endY) };

        //Horizontal move
        if(!moveIsDiagonal&&!moveIsVertical)
        {
            for (int j = lowestPoints[1] + 1; j <= highestPoints[1]; j++)
                if (floor[startX][j] != 'x' && j != startY) 
                    return false;
            return true;
        }

        //Vertical move
        if(!moveIsDiagonal&&moveIsVertical)
        {
            for (int i = lowestPoints[0]; i <= highestPoints[0]; i++)
                if (floor[i][startY] != 'x' && i != startX) 
                    return false;
            return true;
        }

        //Move diagonally
        if(moveIsDiagonal)
        {
            //define the diagonal direction
            var isLeftToRight = (startY < endY && startX < endX) || (startY > endY && startX > endX);

            int j = isLeftToRight ? j = lowestPoints[1] : highestPoints[1];
            
            for(int i=lowestPoints[0];i<=highestPoints[0]; i++)
            {
                if (floor[i][j] != 'x'&&i!=startX&&j!=startY)
                    return false;
                
                if (isLeftToRight)
                    j++;
                else j--;
            }

            return true;
        }

        return false;
    }
}