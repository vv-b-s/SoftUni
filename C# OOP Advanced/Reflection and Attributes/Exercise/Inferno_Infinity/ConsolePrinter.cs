using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity
{
    public class ConsolePrinter : IPrintLocation
    {
        public void Print(string text)
        {
            Console.Write(text);
        }
    }
}
