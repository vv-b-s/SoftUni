using System;
using System.Collections.Generic;
using System.Text;
using Inferno_Infinity.Contracts;

namespace Inferno_Infinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(string name, LevelOfRarity levelOfRarity) : base(name, 3, 4, 2, levelOfRarity) { }
    }
}
