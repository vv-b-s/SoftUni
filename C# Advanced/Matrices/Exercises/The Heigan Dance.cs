using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class TheHeiganDance
{
    static int[,] playField;
    public static void Main(string[] args)
    {
        var player = new Player();
        var heigan = new Heigan(double.Parse(ReadLine()));

        playField = new int[15, 15];

        var lastUsedSpell = "";

        //While the player and heigan are both alive
        while (!player.IsDead && !heigan.IsDead)
        {
            var inputData = ReadLine().Split(' ').Where(i => i != "").ToArray();
            var spell = inputData[0];
            var castPosition = new int[] { int.Parse(inputData[1]), int.Parse(inputData[2]) };

            //In every move heigan gets his default amount of damage
            heigan.Damage();


            //Damage the area
            if (!heigan.IsDead)
                ManipulateField(castPosition, true);

            //If the player has active Plague Cloud from the previous curse, drop player's health once more
            if (player.ActiveCloud > 0)
            {
                player.Health -= heigan.PerformSpell("Cloud");

                // Plague Cloud does not overlap cuz... logic
                player.ActiveCloud = 0;
            }

            //Then check if the somebody died
            if (player.IsDead || heigan.IsDead)
                break;

            //If everybody is ok perform the curent damage to the player if he stands on a damaged cell and can't move away from it
            if (playField[player.Position[0], player.Position[1]] == 1 && !PlayerMoved(player))
                player.Damage(heigan.PerformSpell(spell), spell);

            lastUsedSpell = spell;

            //After all mmodifications, if player had died, the program will stop in order to skip any further modifications of the field
            // which takes time.
            if (player.IsDead)
                break;

            //Clean the area for the next damaging
            ManipulateField(castPosition, false);
        }

        if (heigan.IsDead)
            WriteLine($"Heigan: Defeated!");
        else WriteLine($"Heigan: {heigan.Health:F2}");

        if (player.IsDead)
            WriteLine($"Player: Killed by {(lastUsedSpell == "Eruption" ? lastUsedSpell : "Plague Cloud")}");
        else WriteLine($"Player: {player.Health}");

        WriteLine($"Final position: {player.Position[0]}, {player.Position[1]}");
    }

    /// <summary>
    /// Try to move the player and return the result
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    private static bool PlayerMoved(Player player)
    {
        //Use constants for readability
        const int row = 0;
        const int col = 1;

        //Try to move the player UP if the position is inside the playfield and is not damaged
        if (player.Position[row] - 1 > -1 && playField[player.Position[row] - 1, player.Position[col]] == 0)
        {
            player.Position[row]--;
            return true;
        }

        //Try to move the player RIGHT if the position is inside the playfield and is not damaged
        else if (player.Position[col] + 1 < playField.GetLength(col) && playField[player.Position[row], player.Position[col] + 1] == 0)
        {
            player.Position[1]++;
            return true;
        }

        //Try to move the player DOWN if the position is inside the playfield and is not damaged
        if (player.Position[row] + 1 < playField.GetLength(row) && playField[player.Position[row] + 1, player.Position[col]] == 0)
        {
            player.Position[row]++;
            return true;
        }

        //Try to move the player LEFT if the position is inside the playfield and is not damaged
        else if (player.Position[col] - 1 > -1 && playField[player.Position[row], player.Position[col] - 1] == 0)
        {
            player.Position[col]--;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Either damage or heal the field after the round had finished
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="performDamage"></param>
    private static void ManipulateField(int[] pos, bool performDamage)
    {
        for (int i = pos[0] - 1; i <= pos[0] + 1; i++)
        {
            //If i is in the playfield
            if (i >= 0 && i < playField.GetLength(0))
            {
                for (int j = pos[1] - 1; j <= pos[1] + 1; j++)
                {
                    //if j is in the field
                    if (j >= 0 && j < playField.GetLength(1))
                        playField[i, j] = performDamage ? 1 : 0;
                }
            }
        }
    }
}

internal class Player
{
    internal int[] Position { get; set; }
    internal double Health { get; set; }
    internal bool IsDead => Health <= 0;
    internal int ActiveCloud { get; set; }

    internal Player()
    {
        Position = new int[] { 7, 7 };
        Health = 18_500;
        ActiveCloud = 0;
    }

    internal void Damage(double spellDamage, string spellName)
    {
        Health -= spellDamage;

        if (spellName == "Cloud")
            ActiveCloud += 2;
    }
}

internal class Heigan
{
    internal double Health { get; set; }
    internal bool IsDead => Health <= 0;

    private int plagueCloud = 3500;
    private int eruption = 6000;

    private double damage;

    internal Heigan(double damage)
    {
        Health = 3_000_000;
        this.damage = damage;
    }

    internal void Damage() => Health -= damage;
    internal int PerformSpell(string spellName)
    {
        switch (spellName)
        {
            case "Cloud":
                return plagueCloud;
            case "Eruption":
                return eruption;
            default:
                return 0;
        }
    }
}