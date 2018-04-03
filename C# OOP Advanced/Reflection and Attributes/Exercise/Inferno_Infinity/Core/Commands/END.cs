using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Core.Commands
{
    public class END : ICommand
    {
        public string Execute(string[] args)
        {
            return "STOP";
        }
    }
}
