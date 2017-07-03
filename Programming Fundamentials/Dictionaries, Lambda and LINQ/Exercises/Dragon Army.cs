using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Dragon
{
    private int health = 250;
    private int damage = 45;
    private int armor = 10;

    public string Name { set; get; }
    public int Health => health;
    public int Damage => damage;
    public int Armor => armor;

    public Dragon(string name, string dmg, string hp, string arm)
    {
        Name = name;

        if (hp != "null")
            health = int.Parse(hp);
        if (dmg != "null")
            damage = int.Parse(dmg);
        if (arm != "null")
            armor = int.Parse(arm);
    }

    public void ChangeStats(string dmg, string hp, string arm)
    {
        if (hp != "null")
            health = int.Parse(hp);
        else health = 250;

        if (dmg != "null")
            damage = int.Parse(dmg);
        else damage = 45;

        if (arm != "null")
            armor = int.Parse(arm);
        else armor = 10;
    }
}

class Program
{
    static void Main()
    {
        var TypeStat = new Dictionary<string, List<Dragon>>();

        int numOfDragons = int.Parse(ReadLine());
        for (int i = 0; i < numOfDragons; i++)
        {
            string[] input = ReadLine().Split();
            string type = input[0], name = input[1], dmg = input[2], hp = input[3], arm = input[4];

            if (TypeStat.ContainsKey(type))
            {
                bool noExistingDragonOverwritten = true;

                foreach (var dragon in TypeStat[type])
                    if (dragon.Name == name)
                    {
                        dragon.ChangeStats(dmg, hp, arm);
                        noExistingDragonOverwritten = false;
                    }
                if(noExistingDragonOverwritten)
                    TypeStat[type].Add(new Dragon(name, dmg, hp, arm));
            }
            else
                TypeStat[type] = new List<Dragon> { new Dragon(name, dmg, hp, arm) };
        }

        var AverageStats = new Dictionary<string, List<double>>();
        foreach (var dragonList in TypeStat)
        {
            AverageStats[dragonList.Key] = new List<double>
            {
                dragonList.Value.Average(d=>d.Damage),
                dragonList.Value.Average(d=>d.Health),
                dragonList.Value.Average(d=>d.Armor)
            };
        }

        TypeStat = TypeStat.ToDictionary(k => k.Key, l => l.Value.OrderBy(d => d.Name).ToList());

        foreach (var dragonType in TypeStat)
        {
            Write($"{dragonType.Key}::({AverageStats[dragonType.Key][0]:f2}/{AverageStats[dragonType.Key][1]:f2}/{AverageStats[dragonType.Key][2]:f2})\n" +
                $"{ListDragons(dragonType)}");
        }
    }

    private static object ListDragons(KeyValuePair<string, List<Dragon>> dragonType)
    {
        var output = new StringBuilder();
        foreach (var dragon in dragonType.Value)
            output.AppendLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
        return output;
    }
}