using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private DependencyContainer iocc;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            iocc = new DependencyContainer();
            iocc.AddDependency<IRepository,UnitRepository>(repository as UnitRepository);
            iocc.AddDependency<IUnitFactory, UnitFactory>(unitFactory as UnitFactory);
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            //Get the class which maches the command name with ignred casing
            var commandClass = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => string.Compare(t.Name, commandName, true) == 0);

            if (commandClass is null)
                throw new InvalidOperationException("Invalid command!");

            var commandInstance = iocc.CreateAndInject(commandClass,new object[] { data});

            return commandInstance as IExecutable;
        }
    }
}
