using Inferno_Infinity.Contracts;
using Inferno_Infinity.DI_Mechanism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferno_Infinity.Core.Commands
{
    public class Add : ICommand
    {
        [Inject]
        public IList<IWeapon> Weapons { get; private set; }

        [Inject]
        public IFactory<IGem> GemFactory { get; private set; }

        public string Execute(string[] args)
        {
            var weaponName = args[0];
            var socketIndex = int.Parse(args[1]);

            var gemData = args[2].Split();
            var gemLevelOfClarity = gemData[0];
            var gemType = gemData[1];

            var weapon = this.Weapons.FirstOrDefault(w => w.Name == weaponName);

            if (weapon != null)
            {
                var gem = this.GemFactory.CreateProduct(Type.GetType($"Inferno_Infinity.Models.Gems.{gemType}"), Enum.Parse<LevelOfClarity>(gemLevelOfClarity));

                weapon.AddGem(gem, socketIndex);
            }

            return null;
        }
    }
}
