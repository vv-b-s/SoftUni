using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class CalculateSequenceWithQueue
{
    static void Main(string[] args)
    {
        long number = long.Parse(ReadLine());
        //New numbers will be added here
        var startQueue = new Queue<long>();

        //Numbers chich have their turns expaired will be added here
        var endQueue = new Queue<long>();

        int turn = 1;

        //The first number will be added to the start queue explicitly
        startQueue.Enqueue(number);
        for(int i = 1; i < 50; i++,turn++)
        {
            //Every number at the top of the queue has three expressions to participate in
            long currentNumber = startQueue.Peek();
            switch (turn)
            {
                case 1:
                    startQueue.Enqueue(currentNumber + 1);
                    break;
                case 2:
                    startQueue.Enqueue(2 * currentNumber + 1);
                    break;
                case 3: //when the third expression is completed the participating number will go to the end queue to make plache for the next number
                    startQueue.Enqueue(currentNumber + 2);
                    turn = 0;
                    endQueue.Enqueue(startQueue.Dequeue());
                    break;
            }
        }

        //After the loop is completed all the remaining numbers will be moved to the endQueue
        while(startQueue.Count>0)
            endQueue.Enqueue(startQueue.Dequeue());

        var queueArray = endQueue.ToArray();

        WriteLine(string.Join(" ", queueArray));
    }
}