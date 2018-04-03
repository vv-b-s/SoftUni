using Inferno_Infinity.Contracts;
using Inferno_Infinity.DI_Mechanism;
using Inferno_Infinity.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter(DependencyContainer diContainer)
        {
            this.DIContainer = diContainer;
        }

        public DependencyContainer DIContainer { get; }

        public string ExecuteCommand(string command, params string[] data)
        {
            var commandInstance = DIContainer.CreateAndInject(Type.GetType($"Inferno_Infinity.Core.Commands.{command}")) as ICommand;

            var commandResult = commandInstance.Execute(data);

            return commandResult;
        }
    }
}
