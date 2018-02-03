using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class InfernoIII
{
    private static Dictionary<int, int> indexGem;
    private static int[] gems;
    public static void Main(string[] args)
    {
        var spells = new Dictionary<string, List<KeyValuePair<int, Action<int>>>>();
        gems = ReadLine().Split().Select(int.Parse).ToArray();
        indexGem = new Dictionary<int, int>();

        for (int i = 0; i < gems.Length; i++)
            indexGem[i] = gems[i];

        var input = "";
        while ((input = ReadLine()) != "Forge")
        {
            var data = input.Split(';');
            var operation = data[0];
            var typeOfMagic = data[1];
            var number = int.Parse(data[2]);

            if (operation == "Exclude")
            {
                if (!spells.ContainsKey(typeOfMagic))
                    spells[typeOfMagic] = new List<KeyValuePair<int, Action<int>>>();

                switch (typeOfMagic)
                {
                    case "Sum Left":
                        spells[typeOfMagic].Add(new KeyValuePair<int, Action<int>>(number, n => GemsSumLeft(n)));
                        break;
                    case "Sum Right":
                        spells[typeOfMagic].Add(new KeyValuePair<int, Action<int>>(number, n => GemsSumRight(n)));
                        break;
                    case "Sum Left Right":
                        spells[typeOfMagic].Add(new KeyValuePair<int, Action<int>>(number, n => GemsSumLeftRight(n)));
                        break;

                }
            }
            else if (operation == "Reverse")
            {
                spells[typeOfMagic].RemoveAll(m => m.Key == number);

                if (spells[typeOfMagic].Count == 0)
                    spells.Remove(typeOfMagic);
            }
        }

        //Perform the magic
        foreach (var spell in spells)
        {
            foreach (var magic in spell.Value)
                magic.Value(magic.Key);
        }

        WriteLine(string.Join(" ", indexGem.Values));
    }

    private static void GemsSumLeft(int number)
    {
        var filteredGems = new Queue<KeyValuePair<int, int>>();
        
        foreach(var gem in indexGem)
        {
            var index = gem.Key - 1;
            var previousGem = index < 0 ? 0 : gems[index];
            if (previousGem + gem.Value != number)
                filteredGems.Enqueue(gem);
        }

        indexGem = filteredGems.ToDictionary(k => k.Key, v => v.Value);
    }

    private static void GemsSumRight(int number)
    {
        var filteredGems = new Queue<KeyValuePair<int, int>>();

        foreach (var gem in indexGem)
        {
            var index = gem.Key + 1;
            var nextGem = index >= gems.Length ? 0 : gems[index];
            if (nextGem + gem.Value != number)
                filteredGems.Enqueue(gem);
        }

        indexGem = filteredGems.ToDictionary(k => k.Key, v => v.Value);
    }

    private static void GemsSumLeftRight(int number)
    {
        var filteredGems = new Queue<KeyValuePair<int, int>>();

        foreach (var gem in indexGem)
        {
            var previousIndex = gem.Key - 1;
            var previousGem = previousIndex < 0 ? 0 : gems[previousIndex];

            var mextIndex = gem.Key + 1;
            var nextGem = mextIndex >= gems.Length ? 0 : gems[mextIndex];

            if (previousGem + nextGem + gem.Value != number)
                filteredGems.Enqueue(gem);
        }

        indexGem = filteredGems.ToDictionary(k => k.Key, v => v.Value);
    }
}