using System;
using System.Collections.Generic;
using System.Text;
using Inferno_Infinity.Contracts;

namespace Inferno_Infinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string name, LevelOfRarity levelOfRarity) : base(name, 4, 6, 3, levelOfRarity) { }
    }
}
