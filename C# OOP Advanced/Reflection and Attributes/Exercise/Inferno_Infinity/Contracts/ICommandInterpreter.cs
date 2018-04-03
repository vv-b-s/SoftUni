using Inferno_Infinity.DI_Mechanism;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public interface ICommandInterpreter
    {
        DependencyContainer DIContainer { get; }

        string ExecuteCommand(string command, params string[] data);
    }
}
