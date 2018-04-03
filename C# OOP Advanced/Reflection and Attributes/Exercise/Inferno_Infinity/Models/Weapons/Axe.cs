using System;
using System.Collections.Generic;
using System.Text;
using Inferno_Infinity.Contracts;

namespace Inferno_Infinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(string name, LevelOfRarity levelOfRarity) : base(name, 5, 10, 4, levelOfRarity) { }
    }
}
