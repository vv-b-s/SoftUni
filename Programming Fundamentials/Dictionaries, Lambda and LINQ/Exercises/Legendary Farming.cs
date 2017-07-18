using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var inventory = new Dictionary<string, int>
        {
            { "shards",0 },
            { "fragments",0},
            { "motes",0}
        };

        bool loopIsWorking = true;
        while(loopIsWorking)
        {
            int temp;
            string[] loot = ReadLine().ToLower().Split();
            int[] ammounts = loot.Where(a => int.TryParse(a, out temp)).Select(int.Parse).ToArray();
            string[] items = loot.Where(a => !int.TryParse(a, out temp)).ToArray();

            for(int i=0;i<items.Length;i++)
            {
                if (inventory.Keys.Contains(items[i]))
                {
                    inventory[items[i]] += ammounts[i];
                    loopIsWorking = CheckIfObtained(inventory);
                    if (!loopIsWorking)
                        break;
                }
                else
                {
                    inventory[items[i]] = ammounts[i];
                    loopIsWorking = CheckIfObtained(inventory);
                    if (!loopIsWorking)
                        break;
                }
            }
        }

        var junk = inventory.Where(i => i.Key != "motes" && i.Key != "fragments" && i.Key != "shards").OrderBy(i => i.Key).ToDictionary(i => i.Key, v => v.Value);
        inventory = inventory.Where(i => i.Key == "motes" || i.Key == "fragments" || i.Key == "shards").OrderByDescending(q=>q.Value).ThenBy(n=>n.Key).ToDictionary(i => i.Key, v => v.Value);

        foreach (var item in inventory)
            WriteLine($"{item.Key}: {item.Value}");
        foreach(var item in junk)
            WriteLine($"{item.Key}: {item.Value}");
    }

    private static bool CheckIfObtained(Dictionary<string, int> inventory)
    {
        var filteredInventory = inventory.Where(i => i.Key == "motes" || i.Key == "fragments" || i.Key == "shards").ToDictionary(i => i.Key, v => v.Value);

        foreach (var item in filteredInventory)
        {
            if (item.Value >= 250)
            {
                string obtainedItem = "";
                switch (item.Key)
                {
                    case "shards":
                        obtainedItem = "Shadowmourne"; break;
                    case "fragments":
                        obtainedItem = "Valanyr"; break;
                    case "motes":
                        obtainedItem = "Dragonwrath"; break;
                }
                inventory[item.Key] -= 250;

                WriteLine($"{obtainedItem} obtained!");
                return false;
            }
        }
        return true;
    }
}