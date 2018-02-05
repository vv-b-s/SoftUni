using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class GreedyTimes
{
    public static void Main(string[] args)
    {
        var bagCapacity = long.Parse(ReadLine());

        var items = Regex.Matches(ReadLine(), @"[^\s]+\s+\d+").Cast<Match>().Select(m => m.Value).ToList();

        var gold = 0L;
        var gems = new Dictionary<string, List<long>>();
        var money = new Dictionary<string, List<long>>();

        var goldMathcher = new Regex(@"^Gold\s+(?<goldValue>\d+)");
        var gemMathcer = new Regex(@"(?<gemName>[^\s]+[Gg][Ee][Mm])\s+(?<gemValue>\d+)");
        var moneyMatcher = new Regex(@"^(?<currency>[^\s]{3})\s+(?<moneyValue>\d+)");

        var goldIsTaken = false;
        foreach (var item in items)
        {
            Match match;

            if ((match = goldMathcher.Match(item)).Length > 0)
            {
                var goldValue = long.Parse(match.Groups["goldValue"].Value);
                gold += goldValue;

                //Gold with no value makes no affect to the bag but it is still a gold
                if (goldValue == 0)
                    goldIsTaken = true;
            }

            else if ((match = gemMathcer.Match(item)).Length > 0)
            {
                var gemName = match.Groups["gemName"].Value;
                var gemValue = long.Parse(match.Groups["gemValue"].Value);

                if (!gems.ContainsKey(gemName))
                    gems[gemName] = new List<long>();

                gems[gemName].Add(gemValue);
            }
            else if ((match = moneyMatcher.Match(item)).Length > 0)
            {
                var currency = match.Groups["currency"].Value;
                var moneyValue = long.Parse(match.Groups["moneyValue"].Value);

                if (!money.ContainsKey(currency))
                    money[currency] = new List<long>();

                money[currency].Add(moneyValue);
            }
        }

        long currentCapacity = 0;

        long takenGold = 0;
        long totalValueOfTakenGems = 0;
        long totalValueOfTakenMoney = 0;
        Dictionary<string, long> takenGems = null;
        Dictionary<string, long> takenMoney = null;

        //Take as much gold as possible
        if (gold < bagCapacity)
            takenGold += gold;
        else takenGold = bagCapacity;

        currentCapacity += takenGold;

        if (gems.Count > 0 && currentCapacity <= bagCapacity && takenGold >= 0)
        {
            gems = gems.OrderByDescending(gem => gem.Value.Sum()).ToDictionary(k => k.Key, v => v.Value);

            //There might be values with zero which count as a value so having a list of them is important
            foreach (var gemItem in gems)
            {
                gemItem.Value.Sort();
                var totalAmountTakenOfThisGem = 0l;
                var anyGemsTaken = false;

                foreach(var value in gemItem.Value)
                {
                    if (value + currentCapacity <= bagCapacity && takenGold >= totalValueOfTakenGems + value)
                    {
                        totalValueOfTakenGems += value;
                        currentCapacity += value;
                        totalAmountTakenOfThisGem += value;
                        anyGemsTaken = true;
                    }
                }

                if(anyGemsTaken)
                {
                    if (takenGems is null)
                        takenGems = new Dictionary<string, long>();

                    takenGems[gemItem.Key] = totalAmountTakenOfThisGem;
                }
            }
        }

        if (money.Count > 0 && currentCapacity <= bagCapacity && totalValueOfTakenGems >= 0)
        {
            money = money.OrderByDescending(m => m.Value.Sum()).ToDictionary(k => k.Key, v => v.Value);

            //There might be values with zero which count as a value so having a list of them is important
            foreach (var currency in money)
            {
                currency.Value.Sort();
                var totalAmountTalkenOfTheseMoney = 0l;
                var anyMoneyTaken = false;

                foreach(var value in currency.Value)
                {
                    if (value + currentCapacity <= bagCapacity && totalValueOfTakenGems >= totalValueOfTakenMoney + value)
                    {
                        totalValueOfTakenMoney += value;
                        currentCapacity += value;
                        totalAmountTalkenOfTheseMoney += value;
                        anyMoneyTaken = true;
                    }
                }

                if(anyMoneyTaken)
                {
                    if (takenMoney is null)
                        takenMoney = new Dictionary<string, long>();

                    takenMoney[currency.Key] = totalAmountTalkenOfTheseMoney;
                }
            }
        }

        if (takenGold > 0||goldIsTaken)
        {
            WriteLine($"<Gold> ${takenGold}\n##Gold - {takenGold}");
        }

        if (takenGems != null)
        {
            takenGems = takenGems.OrderByDescending(g => g.Key).ThenBy(g => g.Value).ToDictionary(k => k.Key, v => v.Value);
            WriteLine($"<Gem> ${totalValueOfTakenGems}");
            foreach (var gem in takenGems)
                WriteLine($"##{gem.Key} - {gem.Value}");
        }

        if (takenMoney != null)
        {
            takenMoney = takenMoney.OrderByDescending(m => m.Key).ThenBy(m => m.Value).ToDictionary(k => k.Key, v => v.Value);
            WriteLine($"<Cash> ${totalValueOfTakenMoney}");
            foreach (var currency in takenMoney)
                WriteLine($"##{currency.Key} - {currency.Value}");
        }
    }
}