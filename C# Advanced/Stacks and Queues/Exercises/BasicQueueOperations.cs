using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class BasicQueueOperations
{
    static void Main(string[] args)
    {
        var manipulation = ParseArray();

        var queueSize = manipulation[0];
        var dequeueTimes = manipulation[1];
        var numberToFind = manipulation[2];

        if (queueSize > 0)
        {
            var queue = new Queue<int>(ParseArray());
            while (dequeueTimes > 0)
            {
                queue.Dequeue();
                dequeueTimes--;
            }

            //Getting the queue size again to make sure taht ther are elements left for the rest of the tasks
            queueSize = queue.Count();
            if (queueSize > 0)
            {
                //Checking for a matching number or a max number
                int minNumber = int.MaxValue;
                while(queue.Count>0)
                {
                    int queueNumber = queue.Dequeue();
                 
                    //If a matching number is found the user will be notified and the program will stop.
                    if(queueNumber==numberToFind)
                    {
                        WriteLine("true");
                        return;
                    }

                    //While no matching number is found the value of min number will be updated
                    if (queueNumber < minNumber)
                        minNumber = queueNumber;
                }

                WriteLine(minNumber);
            }
        }

        //In the cases when the queue is empty but it shouldn't, zero would be the outcome.
        if (queueSize == 0)
            WriteLine(0);
    }

    /// <summary>
    /// Parse an array out of a string without empty entries which can lead to SystemFormatExceptions
    /// </summary>
    /// <returns></returns>
    private static int[] ParseArray() => ReadLine()
        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();
}