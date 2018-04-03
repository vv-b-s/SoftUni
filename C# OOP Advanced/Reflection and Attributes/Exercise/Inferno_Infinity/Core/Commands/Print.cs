using Inferno_Infinity.Contracts;
using Inferno_Infinity.DI_Mechanism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferno_Infinity.Core.Commands
{
    public class Print:ICommand
    {
        [Inject]
        public IList<IWeapon> Weapons { get; private set; }

        [Inject]
        public IPrintLocation PrintLocation { get; private set; }

        public string Execute(string[] args)
        {
            var weaponName = args[0];

            var weapon = this.Weapons.FirstOrDefault(w => w.Name == weaponName);

            if (weapon != null)
                PrintLocation.Print(weapon + Environment.NewLine);

            return null;
        }
    }
}
