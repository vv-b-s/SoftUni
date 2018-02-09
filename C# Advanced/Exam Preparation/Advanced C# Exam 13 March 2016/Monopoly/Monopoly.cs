using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    private static char[][] gameBoard;
    private static int playersMoney = 50;
    private static int numberOfHotels;
    private static int turns;

    static void Main()
    {
        numberOfHotels = 0;
        turns = 0;

        var size = ReadLine().Split().Where(i => i != "").Select(int.Parse).ToArray();

        gameBoard = new char[size[0]][];

        for (int i = 0; i < size[0]; i++)
            gameBoard[i] = ReadLine().ToCharArray();

        for(int i = 0;i<size[0];i++)
        {
            if(i%2==0)
            {
                for (int j = 0; j < size[1]; j++)
                    MakeAMove(i, j);
            }
            else
            {
                for (int j = size[1]-1; j >= 0; j--)
                    MakeAMove(i, j);
            }
        }

        WriteLine($"Turns {turns}\nMoney {playersMoney}");
    }

    private static void MakeAMove(int i, int j)
    {
        string message = null;
        switch(gameBoard[i][j])
        {
            case 'H':
                numberOfHotels++;
                message = $"Bought a hotel for {playersMoney}. Total hotels: {numberOfHotels}.";
                playersMoney = 0;
                break;
            case 'J':
                WriteLine($"Gone to jail at turn {turns}.");
                turns += 2;
                playersMoney += 2 * numberOfHotels * 10;
                break;
            case 'S':
                var price = (i+1) * (j+1);
                var spentMoney = 0;
                if (playersMoney > price)
                {
                    playersMoney -= price;
                    spentMoney = price;
                }
                else
                {
                    spentMoney = playersMoney;
                    playersMoney = 0;
                }

                message = $"Spent {spentMoney} money at the shop.";
                break;
        }

        playersMoney += numberOfHotels * 10;
        turns++;

        if (message != null)
            WriteLine(message);
    }
}