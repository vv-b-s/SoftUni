using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class BasicStackOperations
{
    static void Main(string[] args)
    {
        var conditions = ParseArray();

        // Get the parameeters of the stack
        int stackSize = conditions[0];
        int elementsToPop = conditions[1];
        int searchedElement = conditions[2];

        //If the size of the stack is greater than zero run the code below
        if (stackSize > 0)
        {
            //Get the stack values
            var stack = new Stack<int>(ParseArray());

            //Pop the amount of pop cycles
            for (int i = elementsToPop; i > 0; i--)
                stack.Pop();

            //Assign conditions to look for
            int smallestElement = int.MaxValue;
            bool searchedElementFound = false;

            // Getting the stack size again so to recognize if it had been emptied at this point as this value is used outside the loop
            stackSize = stack.Count;
            
            //if the stack is not empty check for the conditions by popping its values to save time looping
            while (stack.Count>0)
            {
                int poppedElement = stack.Pop();
                if (searchedElementFound = poppedElement == searchedElement)
                    break;

                if (smallestElement > poppedElement)
                    smallestElement = poppedElement;
            }

            //Stack might get empty from the popping above so what we're checking here is if the stack had anything before that
            if (stackSize > 0)
            {
                if(searchedElementFound)
                    WriteLine("true");
                else
                    WriteLine(smallestElement);
            }
        }
        
        //In any case where the stack was empty by condition the outcome would always be zero.
        if(stackSize==0)
            WriteLine("0");
    }

    /// <summary>
    /// Parse an array out of a string without empty entries which can lead to SystemFormatExceptions
    /// </summary>
    /// <returns></returns>
    private static int[] ParseArray() => ReadLine()
        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();
}
