using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
