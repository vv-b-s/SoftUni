using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var field = new bool[int.Parse(ReadLine())];
        var ladyBugsInIndexes = Regex.Split(ReadLine(), @"\s+")
            .Select(int.Parse)
            .Where(bug => bug >= 0 && bug <= field.Length - 1)
            .ToArray();

        for (int i = 0; i < field.Length; i++)
            field[i] = ladyBugsInIndexes.Contains(i);

        string input;
        while((input=ReadLine())!="end")
        {
            var ladyBugIndex = int.Parse(input.Split()[0]);
            var positionToMove = input.Split()[1];
            var moveLen = int.Parse(input.Split()[2]);
            var ladybugNotMoved = true;

            if(ladyBugIndex>=0&&ladyBugIndex<=field.Length-1&&field[ladyBugIndex]&&moveLen!=0)
            {
                switch(positionToMove)
                {
                    case "left":
                        while(ladybugNotMoved)
                        {
                            if (LadybugIsInArray(field, ladyBugIndex, moveLen, "left"))
                            {
                                if(field[ladyBugIndex-moveLen])
                                {
                                    moveLen += moveLen;
                                    continue;
                                }
                                else
                                {
                                    field[ladyBugIndex] = false;
                                    field[ladyBugIndex - moveLen] = true;
                                    ladybugNotMoved = false;
                                }
                            }
                            else
                            {
                                field[ladyBugIndex] = false;
                                ladybugNotMoved = false;
                            }
                        }
                        break;
                    case "right":
                        while (ladybugNotMoved)
                        {
                            if (LadybugIsInArray(field, ladyBugIndex, moveLen, "right"))
                            {
                                if (field[ladyBugIndex + moveLen])
                                {
                                    moveLen += moveLen;
                                    continue;
                                }
                                else
                                {
                                    field[ladyBugIndex] = false;
                                    field[ladyBugIndex + moveLen] = true;
                                    ladybugNotMoved = false;
                                }
                            }
                            else
                            {
                                field[ladyBugIndex] = false;
                                ladybugNotMoved = false;
                            }
                        }
                        break;
                }
            }
        }
        var ladyBugsAvailable = field.Select(i => i ? 1 : 0).ToArray();
        WriteLine(string.Join(" ", ladyBugsAvailable));
    }

    private static bool LadybugIsInArray(bool[] field, int ladyBugIndex, int move,string position)
    {
        switch(position)
        {
            case "left":
                return ladyBugIndex - move >= 0;
            case "right":
                return ladyBugIndex + move <= field.Length - 1;
            default:
                return false;
        }
    }
}