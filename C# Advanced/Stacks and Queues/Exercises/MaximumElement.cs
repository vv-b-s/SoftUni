using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class MaximumElement
{
    static void Main(string[] args)
    {
        int numberOfOperations = int.Parse(ReadLine());
        var numberStack = new Stack<long>();
        var maxTracker = new Stack<long>();

        while (numberOfOperations > 0)
        {
            var operationData = ParseArray();
            long operation = operationData[0];

            switch (operation)
            {
                case 1:
                    var numberToAdd = operationData[1];
                    numberStack.Push(numberToAdd);

                    //If it is the first number being added it will be considered as the first max number. otherwise a max number will be a greater number 
                    //than the last added
                    if (maxTracker.Count == 0 || maxTracker.Peek() < numberToAdd)
                        maxTracker.Push(numberToAdd);
                    break;
                case 2:
                    if (numberStack.Count > 0)
                    {
                        long poppedNumber = numberStack.Pop();

                        //since the max numbers are synchronised with the main stack when a max number is popped it should match the last max number
                        // on the maxTracker
                        if (maxTracker.Peek() == poppedNumber)
                            maxTracker.Pop();
                    }
                    break;
                case 3:
                    //Alogorithm found from: http://algorithms.tutorialhorizon.com/track-the-maximum-element-in-a-stack/
                    if(maxTracker.Count>0)
                        WriteLine(maxTracker.Peek());
                    break;
            }

            numberOfOperations--;
        }
    }

    /// <summary>
    /// Parse an array out of a string without empty entries which can lead to SystemFormatExceptions
    /// </summary>
    /// <returns></returns>
    private static int[] ParseArray() => ReadLine()
        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();
}