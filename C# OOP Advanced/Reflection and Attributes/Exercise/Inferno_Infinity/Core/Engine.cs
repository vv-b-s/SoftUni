using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferno_Infinity.Core
{
    public class Engine
    {
        ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Start()
        {
            var output = "";
            do
            {
                var input = Console.ReadLine();

                var data = input.Split(";");
                var command = data[0];
                data = data.Skip(1).ToArray();

                output = commandInterpreter.ExecuteCommand(command, data);
            } while (output != "STOP");
        }
    }
}
