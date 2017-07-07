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
        var elements = ReadLine().Split().Select(int.Parse).ToList();

        bool elementsModified = true;
        while (elementsModified)
        {
            elementsModified = false;
            for (int i = 0; i < elements.Count; i++)
            {
                if (i == 0&&elements.Count>1)
                {
                    if (elements[i + 1] == elements[i])
                    {
                        elements.RemoveAt(i);
                        elementsModified = true;
                        break;
                    }
                }
                else if (i!=0&&i!=elements.Count-1)
                {
                    if (elements[i - 1] + elements[i + 1] == elements[i])
                    {
                        elements.RemoveAt(i + 1);
                        elements.RemoveAt(i - 1);
                        elementsModified = true;
                        break;
                    }
                }
                else if(i==elements.Count-1&&elements.Count>1)
                {
                    if (elements[elements.Count - 2] == elements[i])
                    {
                        elements.RemoveAt(i);
                        elementsModified = true;
                        break;
                    }
                }
            }
        }

        WriteLine(string.Join(" ", elements));
    }
}
