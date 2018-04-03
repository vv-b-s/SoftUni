using Inferno_Infinity.Contracts;
using Inferno_Infinity.Core;
using Inferno_Infinity.DI_Mechanism;
using Inferno_Infinity.Factories;
using Inferno_Infinity.Models.Weapons;
using System;
using System.Collections.Generic;

namespace Inferno_Infinity
{
    class Program
    {
        static void Main(string[] args)
        {
            var diContainer = new DependencyContainer();

            diContainer.AddDependency<IFactory<IWeapon>, WeaponFactory>(new WeaponFactory());
            diContainer.AddDependency<IFactory<IGem>, GemFactory>(new GemFactory());
            diContainer.AddDependency<IList<IWeapon>, List<IWeapon>>(new List<IWeapon>());
            diContainer.AddDependency<IPrintLocation, ConsolePrinter>(new ConsolePrinter());
            diContainer.AddDependency<IMetadataController, MetadataController>(new MetadataController());

            var commandInterpreter = new CommandInterpreter(diContainer);

            var engine = new Engine(commandInterpreter);
            engine.Start();
        }
    }
}
