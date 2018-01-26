using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

class MashPotato
{
    static void Main()
    {
        var participants = new Queue<string>(ReadLine().Split(' '));
        int removeStep = int.Parse(ReadLine());

        if (removeStep == 0)
            return;

        int cycle = 1;
        while (participants.Count > 1)
        {
            bool isPrime = IsPrime(cycle);
            for(int i = 0; i < removeStep-1; i++)
            {
                participants.Enqueue(participants.Dequeue());
            }

            if (!isPrime)
            {
                string removedParticipant = participants.Dequeue();
                WriteLine($"Removed {removedParticipant}");
            }
            else
                WriteLine($"Prime {participants.Peek()}");
            cycle++;
        }

        WriteLine($"Last is {participants.Dequeue()}");
    }

    public static bool IsPrime(long number)
    {
        if (number == 1 || number == 0) return false;
        if (number == 2) return true;

        var boundary = (long)Math.Floor(Math.Sqrt(number));

        for (long i = 2; i <= boundary; ++i)
            if (number % i == 0) return false;

        return true;
    }
}
