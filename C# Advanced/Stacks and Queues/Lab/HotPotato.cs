using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

class HotPotato
{
    static void Main()
    {
        var participants = new Queue<string>(ReadLine().Split(' '));
        int removeStep = int.Parse(ReadLine());

        if (removeStep == 0)
            return;

        while (participants.Count > 1)
        {
            //Like moving through a deck of cards the first card goes to the back
            for(int i = 0; i < removeStep-1; i++)
            {
                participants.Enqueue(participants.Dequeue());
            }

            string removedParticipant = participants.Dequeue();
            WriteLine($"Removed {removedParticipant}");
        }

        WriteLine($"Last is {participants.Dequeue()}");
    }
}
