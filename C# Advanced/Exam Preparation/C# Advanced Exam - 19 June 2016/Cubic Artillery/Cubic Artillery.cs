using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    private static int bunkersCapacity;
    static void Main()
    {
        bunkersCapacity = int.Parse(ReadLine());
        var bunkerFill = 0;
        //A bunker has a name and weapons
        Queue<KeyValuePair<string, Queue<int>>> bunkers = new Queue<KeyValuePair<string, Queue<int>>>();

        var input = "";
        while ((input = ReadLine()) != "Bunker Revision")
        {
            var inputData = input.Split();

            for(int i =0;i<inputData.Length;i++)
            {
                var data = inputData[i];

                if (int.TryParse(data, out int weapon))
                {
                    var weaponIsInBunker = false;

                    while (!weaponIsInBunker)
                    {
                        var bunker = bunkers.Peek();
                        var leftCapacity = bunkersCapacity - bunkerFill;

                        if (WeaponCanBeStoredInBunker(leftCapacity, weapon))
                        {
                            bunker.Value.Enqueue(weapon);
                            weaponIsInBunker = true;
                            bunkerFill += weapon;
                        }
                        else if (bunkers.Count == 1)
                        {
                            if (bunkersCapacity >= weapon)
                            {
                                while (leftCapacity < weapon)
                                {
                                    var thrownWeapon = bunker.Value.Dequeue();
                                    bunkerFill -= thrownWeapon;
                                    leftCapacity += thrownWeapon;
                                }

                                bunker.Value.Enqueue(weapon);
                                bunkerFill += weapon;
                                weaponIsInBunker = true;
                            }
                            else break;
                        }
                        else if (bunkers.Count > 1)
                        {
                            bunkerFill = 0;
                            if (bunkersCapacity < weapon)
                            {
                                while (bunkers.Count > 1)
                                    DequeueAndPrintBunker(bunkers);
                            }
                            else DequeueAndPrintBunker(bunkers);
                        }
                    }
                }
                else bunkers.Enqueue(new KeyValuePair<string, Queue<int>>(data, new Queue<int>()));
            }
        }
    }

    private static bool WeaponCanBeStoredInBunker(int leftCapacity, int weapon) => weapon <= leftCapacity;

    private static void DequeueAndPrintBunker(Queue<KeyValuePair<string, Queue<int>>> bunkers)
    {
        var bunker = bunkers.Dequeue();
        WriteLine($"{bunker.Key} -> {(bunker.Value.Count() > 0 ? string.Join(", ", bunker.Value) : "Empty")}");
    }
}
