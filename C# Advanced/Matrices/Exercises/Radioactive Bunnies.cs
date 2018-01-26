using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class RadioactiveBunnies
{
    //use this structure to keep track of the buies on each line
    private static Dictionary<int, HashSet<int>> bunniesPosition;
    public static void Main(string[] args)
    {

        var sizes = ReadLine().Split(' ').Select(int.Parse).ToArray();

        bunniesPosition = new Dictionary<int, HashSet<int>>();
        var playerPos = new int[2];

        for (int i = 0; i < sizes[0]; i++)
        {
            //create a row for bunnies
            bunniesPosition[i] = new HashSet<int>();

            //Get the curent row
            var rowData = ReadLine().ToCharArray();
            for (int j = 0; j < rowData.Length; j++)
            {
                //If there is a bunny on the curent position, add it to the row
                if (rowData[j] == 'B')
                    bunniesPosition[i].Add(j);
                //Otherwise look only for the player's position
                else if (rowData[j] == 'P')
                {
                    playerPos[0] = i;
                    playerPos[1] = j;
                }
            }
        }
        var commands = ReadLine();

        var outcome = "";
        foreach (var command in commands)
        {
            if (command == 'L')
                playerPos[1]--;
            else if (command == 'R')
                playerPos[1]++;
            else if (command == 'U')
                playerPos[0]--;
            else if (command == 'D')
                playerPos[0]++;

            SpreadBunnies(sizes[1]);

            var playerStatus = GetPlayerStatus(playerPos, sizes[0], sizes[1]);

            if (playerStatus == "won")
            {
                //Align player position
                if (playerPos[0] < 0)
                    playerPos[0]++;
                if (playerPos[1] < 0)
                    playerPos[1]++;
                if (playerPos[0] > sizes[0] - 1)
                    playerPos[0]--;
                if (playerPos[1] > sizes[1] - 1)
                    playerPos[1]--;

                outcome = $"won: {playerPos[0]} {playerPos[1]}";
                break;
            }
            else if (playerStatus == "dead")
            {
                outcome = $"dead: {playerPos[0]} {playerPos[1]}";
                break;
            }
        }

        //Print the aftermath
        var sB = new StringBuilder();
        for(int i = 0; i < sizes[0]; i++)
        {
            for(int j = 0;j<sizes[1];j++)
            {
                if (bunniesPosition[i].Contains(j))
                    sB.Append('B');
                else sB.Append('.');
            }
            sB.AppendLine();
        }

        Write(sB.ToString());
        WriteLine(outcome);
    }

    private static string GetPlayerStatus(int[] position, int height, int width)
    {
        // if a value is out of the matrix, the player had win
        if (position[0]<0||position[0]>=height||position[1]<0||position[1]>=width)
            return "won";
        //Otherwise iff there is a bunnie on the player
        if (bunniesPosition[position[0]].Contains(position[1]))
            return "dead";

        return null;
    }

    /// <summary>
    /// Use the bunnie position hashsets to spread the bunnies
    /// </summary>
    /// <param name="width"></param>
    private static void SpreadBunnies(int width)
    {
        //Create temporal place to store all the new bunnies so the multiplication speed is normal
        var positionsToAddBunnies = new Dictionary<int, HashSet<int>>();

        //Add the bunnies
        for (int i = 0; i < bunniesPosition.Count; i++)
        {
            if (!positionsToAddBunnies.ContainsKey(i))
                positionsToAddBunnies[i] = new HashSet<int>();

            var bunnies = bunniesPosition[i].ToArray();
            foreach(var bunnie in bunnies)
            {
                int newBunnieLeft = bunnie - 1;
                int newBunnieRight = bunnie + 1;
                var positionUp = i - 1;
                var positionDown = i + 1;

                if (newBunnieLeft >= 0)
                    positionsToAddBunnies[i].Add(newBunnieLeft);
                if (newBunnieRight <= width -1)
                    positionsToAddBunnies[i].Add(newBunnieRight);
                if (positionUp >= 0)
                    positionsToAddBunnies[positionUp].Add(bunnie);
                if (positionDown <= bunniesPosition.Count - 1)
                {
                    if (!positionsToAddBunnies.ContainsKey(positionDown))
                        positionsToAddBunnies[positionDown] = new HashSet<int>();
                    positionsToAddBunnies[positionDown].Add(bunnie);
                }
                    
            }
        }

        //Copy the data to the original structure
        foreach(var bunnieSet in positionsToAddBunnies)
        {
            foreach(var bunnie in bunnieSet.Value)
            {
                bunniesPosition[bunnieSet.Key].Add(bunnie);
            }
        }
    }
}