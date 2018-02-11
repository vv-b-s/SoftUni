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
        var priceOfaBullet = int.Parse(ReadLine());
        var barrelSize = int.Parse(ReadLine());
        var barrel = new Queue<int>();
        var bullets = new Stack<int>(ReadArray());
        var locks = new Queue<int>(ReadArray());
        var valueOfIntelligence = int.Parse(ReadLine());

        var spentMoney = 0;
        ReloadBarrel(barrel, bullets, barrelSize);

        while(locks.Count>0)
        {
            var bullet = barrel.Dequeue();
            spentMoney += priceOfaBullet;
            var @lock = locks.Peek();

            if(bullet<=@lock)
            {
                locks.Dequeue();
                WriteLine("Bang!");
            }
            else if(bullet>@lock)
                WriteLine("Ping!");

            if (barrel.Count == 0)
            {
                if (!ReloadBarrel(barrel, bullets, barrelSize))
                    break;
                else
                    WriteLine("Reloading!");
            }
        }

        if (locks.Count == 0)
        {
            var bulletsLeft = barrel.Count + bullets.Count;
            var moneyEarned = valueOfIntelligence - spentMoney;
            WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
        }
        else if (locks.Count > 0)
            WriteLine($"Couldn't get through. Locks left: {locks.Count}");
    }

    private static IEnumerable<int> ReadArray() => ReadLine().Split().Where(i => i != "").Select(int.Parse);
    private static bool ReloadBarrel(Queue<int> barrel, Stack<int> bullets, int barrelSize)
    {
        if (bullets.Count == 0)
            return false;

        for (int i = 0; i < barrelSize && bullets.Count > 0; i++)
            barrel.Enqueue(bullets.Pop());

        return barrel.Count > 0;
    }
}