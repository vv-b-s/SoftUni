using System;
using System.Collections.Generic;
using System.Text;
using Twitter.App.Contracts;

namespace Twitter.App.Model
{
    class ConsoleWrapper : IConsole
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
