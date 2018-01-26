using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class ParkingSystem
{
    static Dictionary<int, HashSet<int>> parklot;

    public static void Main(string[] args)
    {
        var parkLotParameters = ReadLine().Split(' ').Where(i => i != "").Select(int.Parse).ToArray();
        parklot = new Dictionary<int, HashSet<int>>();

        string input;
        while ((input = ReadLine()) != "stop")
        {
            var carDetails = input.Split(' ').Where(i => i != "").Select(int.Parse).ToArray();
            var enteranceRow = carDetails[0];
            var desiredPos = new int[] { carDetails[1], carDetails[2] };

            //Find the shortest distance to park
            if (ParkPositionFound(enteranceRow, desiredPos, parkLotParameters, out int distance)) 
            {
                //Park the car
                parklot[desiredPos[0]].Add(desiredPos[1]);

                //Notify the taken distance from the enterance
                WriteLine(distance);
            }
            else
                WriteLine($"Row {desiredPos[0]} full");
        }

    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="enteranceRow"></param>
    /// <param name="desiredPos"></param>
    private static bool ParkPositionFound(int enteranceRow, int[] desiredPos, int[] parameters, out int distance)
    {
        var distanceToRow = Math.Abs(desiredPos[0] - enteranceRow) + 1;
        
        if(!parklot.ContainsKey(desiredPos[0]))
        {
            parklot[desiredPos[0]] = new HashSet<int>() { desiredPos[1] };
            distance = distanceToRow + desiredPos[1];
            return true;
        }

        //Look for parking spots nearby
        var spots = new int[2];

        //On the left
        for(int i = desiredPos[1];i>0;i--)
        {
            if (!parklot[desiredPos[0]].Contains(i))
            {
                spots[0] = i;
                break;
            }
        }

        //On the right
        for (int i = desiredPos[1]; i < parameters[1]; i++)
        {
            if (!parklot[desiredPos[0]].Contains(i))
            {
                spots[1] = i;
                break;
            }
        }

        //decide which spot to use
        if(spots[0]>0&&spots[1]==0)
        {
            desiredPos[1] = spots[0];
            distance = distanceToRow + spots[0];
            return true;
        }
        else if (spots[1] > 0 && spots[0] == 0)
        {
            desiredPos[1] = spots[1];
            distance = distanceToRow + spots[1];
            return true;
        }
        else if(spots[0]!=0&&spots[1]!=0)
        {
            int[] diffs = { desiredPos[1] - spots[0], spots[1] - desiredPos[1] };

            if (diffs[0] <= diffs[1])
                desiredPos[1] = spots[0];
            else
                desiredPos[1] = spots[1];

            distance = distanceToRow + desiredPos[1];
            return true;
        }

        distance = 0;
        return false;
    }
}
