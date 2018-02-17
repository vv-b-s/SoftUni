using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string itemString = safe[i];
                long amount = long.Parse(safe[i + 1]);

                string itemType = string.Empty;

                if (itemString.Length == 3)
                    itemType = "Cash";

                else if (itemString.ToLower().EndsWith("gem"))
                    itemType = "Gem";

                else if (itemString.ToLower() == "gold")
                    itemType = "Gold";

                if (itemType == "")
                    continue;

                else if (input < GetCurrentBagAmount(bag) + amount) 
                    continue;


                switch (itemType)
                {
                    case "Gem":
                        if (ItemShouldStay(bag, amount, itemType, "Gold"))
                            continue;
                        break;
                    case "Cash":
                        if (ItemShouldStay(bag, amount, itemType, "Gem"))
                            continue;
                        break;
                }

                if (!bag.ContainsKey(itemType))
                    bag[itemType] = new Dictionary<string, long>();
                

                if (!bag[itemType].ContainsKey(itemString))
                    bag[itemType][itemString] = 0;

                bag[itemType][itemString] += amount;

                if (itemType == "Gold")
                    gold += amount;

                else if (itemType == "Gem")
                    gems += amount;

                else if (itemType == "Cash")
                    money += amount;
            }

            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                foreach (var item2 in item.Value.OrderByDescending(itemName => itemName.Key).ThenBy(itemValue => itemValue.Value))
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
            }
        }

        private static double GetCurrentBagAmount(Dictionary<string, Dictionary<string, long>> bag) =>
             bag.Values.Select(x => x.Values.Sum()).Sum();

        private static bool ItemShouldStay(Dictionary<string, Dictionary<string, long>> bag, long amount, string itemType, string itemOfHigherImportance)
        {
            if (!bag.ContainsKey(itemType))
            {
                if (bag.ContainsKey(itemOfHigherImportance))
                {
                    if (amount > bag[itemOfHigherImportance].Values.Sum())
                        return true;
                }
                else return true;
            }

            else if (bag[itemType].Values.Sum() + amount > bag[itemOfHigherImportance].Values.Sum())
                return true;

            return false;
        }
    }
}