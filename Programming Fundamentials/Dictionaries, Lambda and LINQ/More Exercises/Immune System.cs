using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Console;

class ImmuneSystem
{
    Dictionary<string,int> VirusDatabase = new Dictionary<string, int>();

    private int intitalHealth;

    public int Health { set; get; }

    public ImmuneSystem(int initialHealth)
    {
        this.intitalHealth = initialHealth;
        Health = intitalHealth;
    }

    public bool EncounterVirus(string virus, ref int defeatTime, ref int virusStrength)
    {
        if (VirusDatabase.ContainsKey(virus))
        {
            virusStrength = VirusDatabase[virus];
            defeatTime = virusStrength * virus.Length / 3;
            if (defeatTime < Health)
            {
                Health -= defeatTime;
                return true;
            }
            return false;
        }
        virusStrength = virus.ToCharArray().Sum(e => (int) e) / 3;
        defeatTime = virusStrength * virus.Length;
        
        if (defeatTime > Health)
            return false;
        
        Health -= defeatTime;
        VirusDatabase[virus] = virusStrength;
        return true;
    }

    public void HealSystem()
    {
        Health = (int) (Health * 1.2);
        if (Health > intitalHealth)
            Health = intitalHealth;
    }
}

class Program
{
    static void Main()
    {
        string virus;
        bool immuneSystemExists = false;
        var immuneSystem = new ImmuneSystem(int.Parse(ReadLine()));
        while ((virus=ReadLine())!="end")
        {
            int virusStrength=0, defeatTime=0;
            immuneSystemExists = immuneSystem.EncounterVirus(virus, ref defeatTime, ref virusStrength);
            if (immuneSystemExists)
            {
                WriteLine($"Virus {virus}: {virusStrength} => {defeatTime} seconds\n" +
                          $"{virus} defeated in {ConvertToMinutes(defeatTime)}.\n" +
                          $"Remaining health: {immuneSystem.Health}");
                immuneSystem.HealSystem();
            }
            else
            {
                WriteLine($"Virus {virus}: {virusStrength} => {defeatTime} seconds\n" +
                          $"Immune System Defeated.");
                          return;
            }
        }
        
        if(immuneSystemExists)
            WriteLine($"Final Health: {immuneSystem.Health}");
    }

    static string ConvertToMinutes(int seconds)
    {
        int minutes = seconds / 60;
        seconds -= minutes * 60;

        return $"{minutes}m {seconds}s";
    }
}