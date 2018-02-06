using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var player1 = new Queue<string>(ReadLine().Split());
        var player2 = new Queue<string>(ReadLine().Split());

        var numberOfTurns = 0;
        for (int i = 0; i < 1000000 && (player1.Count > 0 && player2.Count > 0); i++)
        {
            numberOfTurns = i + 1;

            var playerCards = new string[] { player1.Dequeue(), player2.Dequeue() };
            var cardPowers = new int[] { GetCardValue(playerCards[0]), GetCardValue(playerCards[1]) };

            if (cardPowers[0] > cardPowers[1])
            {
                player1.Enqueue(playerCards[0]);
                player1.Enqueue(playerCards[1]);
            }
            else if (cardPowers[0] < cardPowers[1])
            {
                player2.Enqueue(playerCards[1]);
                player2.Enqueue(playerCards[0]);
            }
            else if (cardPowers[0] == cardPowers[1])
            {
                var winnerCards = new List<string>();
                winnerCards.Add(playerCards[0]);
                winnerCards.Add(playerCards[1]);

                while (true)
                {
                    if (player1.Count < 3 && player2.Count < 3)
                    {
                        player1.Clear();
                        player2.Clear();
                        break;
                    }
                    if (player1.Count < 3)
                    {
                        player1.Clear();
                        break;
                    }
                    if (player2.Count < 3)
                    {
                        player2.Clear();
                        break;
                    }

                    var player1ThreeCards = new string[] { player1.Dequeue(), player1.Dequeue(), player1.Dequeue() };
                    var player2ThreeCards = new string[] { player2.Dequeue(), player2.Dequeue(), player2.Dequeue() };

                    var player1CardPower = player1ThreeCards.Select(c => AddCardToWinnerCardsAndReturnPower(winnerCards, c)).Sum();
                    var player2CardPower = player2ThreeCards.Select(c => AddCardToWinnerCardsAndReturnPower(winnerCards,c)).Sum();

                    if (player1CardPower > player2CardPower)
                    {
                        AddWinnerCardsToPlayer(player1, winnerCards);
                        break;
                    }
                    else if (player2CardPower > player1CardPower)
                    {
                        AddWinnerCardsToPlayer(player2, winnerCards);
                        break;
                    }
                }
            }
        }

        var result = "";
        if (player1.Count > player2.Count)
            result = "First";
        if (player2.Count > player1.Count)
            result = "Second";

        WriteLine(result != "" ? $"{result} player wins after {numberOfTurns} turns" : $"Draw after {numberOfTurns} turns");
    }

    private static int AddCardToWinnerCardsAndReturnPower(List<string> winnerCards, string card)
    {
        winnerCards.Add(card);
        return GetCardLetterValue(card);
    }

    private static void AddWinnerCardsToPlayer(Queue<string> player, List<string> winnerCards)
    {
        var cardSet = winnerCards.OrderByDescending(c => GetCardValue(c));
        foreach (var card in cardSet)
            player.Enqueue(card);
    }

    private static int GetCardValue(string card) => int.Parse(card.Substring(0,card.Length-1));
    private static int GetCardLetterValue(string card) => card[card.Length-1] - 96;
}