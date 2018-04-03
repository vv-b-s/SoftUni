using Inferno_Infinity.Contracts;
using Inferno_Infinity.DI_Mechanism;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Core.Commands
{
    class Create : ICommand
    {
        [Inject]
        public IFactory<IWeapon> WeaponFactory { get; private set; }

        [Inject]
        public IList<IWeapon> Weapons { get; private set; }

        public string Execute(string[] args)
        {
            var data = args[0].Split();
            var levelOfRarity = Enum.Parse<LevelOfRarity>(data[0]);
            var weaponType = data[1];

            var weaponName = args[1];

            var weapon = WeaponFactory.CreateProduct(Type.GetType($"Inferno_Infinity.Models.Weapons.{weaponType}"), weaponName, levelOfRarity);
            this.Weapons.Add(weapon);

            return null;
        }
    }
}
