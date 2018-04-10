using System;
using System.Collections.Generic;
using System.Text;

class EventLogger : Logger
{
    public override void Handle(LogType type, string message)
    {
        switch (type)
        {
            case LogType.ERROR:
            case LogType.EVENT:
                Console.WriteLine($"{type}: {message}");
                break;
        }

        this.PassToSuccessor(type, message);
    }
}

