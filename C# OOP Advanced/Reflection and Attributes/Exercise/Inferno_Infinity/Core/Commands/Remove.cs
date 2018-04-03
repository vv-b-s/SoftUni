using Inferno_Infinity.Contracts;
using Inferno_Infinity.DI_Mechanism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferno_Infinity.Core.Commands
{
    public class Remove : ICommand
    {
        [Inject]
        public IList<IWeapon> Weapons { get; private set; }

        public string Execute(string[] args)
        {
            var nameOfWeapon = args[0];
            var index = int.Parse(args[1]);

            var weapon = this.Weapons.FirstOrDefault(w => w.Name == nameOfWeapon);
            
            if(weapon!=null)
                weapon.RemoveGem(index);

            return null;
        }
    }
}
