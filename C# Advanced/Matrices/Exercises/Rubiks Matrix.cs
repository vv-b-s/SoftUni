using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class RubiksMatrix
{
    //Use dictionary to keep each value's location
    private static Dictionary<long, int[]> valuesLocation;

    private static long[,] cubeMatrix;

    public static void Main(string[] args)
    {
        var cubeParams = ReadLine().Split(' ').Select(int.Parse).ToArray();
        var numberOfCommands = int.Parse(ReadLine());

        cubeMatrix = new long[cubeParams[0], cubeParams[1]];

        valuesLocation = new Dictionary<long, int[]>();

        //Use those to keep the values of rows and columns
        var tempRowArray = new long[cubeParams[0]];
        var tempColArray = new long[cubeParams[1]];

        //Initialize cubeMatrix values
        var value = 1L;
        for (int i = 0; i < cubeMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < cubeMatrix.GetLength(1); j++)
            {
                cubeMatrix[i, j] = value;
                valuesLocation[value] = new int[] { i, j };
                value++;
            }
        }

        //Rearrange the cube
        while (numberOfCommands-- > 0)
        {
            var query = ReadLine().Split(' ').Where(n => n != "").ToArray();
            var command = query[1];

            //Use these variables to have either fixed row or column
            int row = int.Parse(query[0]), col = row;

            //The times needed to rotate the cube
            var flips = int.Parse(query[2]);

            switch (command)
            {
                case "up": RotateElements(flips, false, col, false); break;
                case "down": RotateElements(flips, false, col, true); break;
                case "left": RotateElements(flips, true, row, false); break;
                case "right": RotateElements(flips, true, row, true); break;
            }
        }

        //Restore matrix values
        value = 1;
        for(int i = 0;i<cubeMatrix.GetLength(0);i++)
        {
            for(int j = 0; j < cubeMatrix.GetLength(1); j++)
            {
                if (value == cubeMatrix[i, j])
                    WriteLine("No swap required");
                else
                {
                    var valLoc = valuesLocation[value];

                    //Notify about the swap
                    WriteLine($"Swap ({i}, {j}) with ({valLoc[0]}, {valLoc[1]})");

                    //Perform the swap
                    var movedValue = cubeMatrix[i, j];

                    cubeMatrix[valLoc[0], valLoc[1]] = movedValue;
                    cubeMatrix[i, j] = value;

                    valuesLocation[movedValue][0] = valLoc[0];
                    valuesLocation[movedValue][1] = valLoc[1];
                    valuesLocation[value][0] = i;
                    valuesLocation[value][1] = j;
                }

                value++;
            }
        }
    }


    /// <summary>
    /// Extract an array from the matrix and rotate it as many times as needed
    /// </summary>
    /// <param name="times"></param>
    /// <param name="moveRow"></param>
    /// <param name="fixedLocation"></param>
    /// <param name="rotateForward"></param>
    private static void RotateElements(int times, bool moveRow, int fixedLocation, bool rotateForward)
    {
        //Use thosa arrays for faster rotation
        long[] firstArray, secondArray;

        //Get the elements from the array into the queue
        if (moveRow)
        {
            firstArray = new long[cubeMatrix.GetLength(1)];
            times %= firstArray.Length;

            //All further steps are useless if the rotation times actually have no effect 
            if (times == firstArray.Length || times == 0)
                return;

            for (int i = 0; i < firstArray.Length; i++)
                firstArray[i] = cubeMatrix[fixedLocation, i];
        }
        else
        {
            firstArray = new long[cubeMatrix.GetLength(0)];
            times %= firstArray.Length;

            //All further steps are useless if the rotation times actually have no effect 
            if (times == firstArray.Length || times == 0)
                return;

            for (int i = 0; i < firstArray.Length; i++)
                firstArray[i] = cubeMatrix[i, fixedLocation];
        }


        //Performing the rotation
        secondArray = new long[firstArray.Length];

        if (rotateForward)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                var index = (i + times) % firstArray.Length;
                secondArray[index] = firstArray[i];
            } 
        }
        else
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                var index = (i - times);

                if (index < 0)
                    index += firstArray.Length;

                secondArray[index] = firstArray[i];
            } 
        }

        //Restore the values and save their location
        UpdateMatrixValues(moveRow, fixedLocation, secondArray);
    }

    /// <summary>
    /// Restore the values in the matrix and save there location
    /// </summary>
    /// <param name="moveRow"></param>
    /// <param name="fixedLocation"></param>
    /// <param name="arrayToRestore"></param>
    private static void UpdateMatrixValues(bool moveRow, int fixedLocation, long[] arrayToRestore)
    {
        if (moveRow)
        {
            for (int i = 0; i < cubeMatrix.GetLength(1); i++)
            {
                var value = arrayToRestore[i];
                cubeMatrix[fixedLocation,i] = arrayToRestore[i];
                valuesLocation[value][0] = fixedLocation;
                valuesLocation[value][1] = i;
            }
        }
        else
        { 
            for (int i = 0; i < cubeMatrix.GetLength(0); i++)
            {
                var value = arrayToRestore[i];
                cubeMatrix[i, fixedLocation] = arrayToRestore[i];
                valuesLocation[value][0] = i;
                valuesLocation[value][1] = fixedLocation;
            }
        }
    }

}