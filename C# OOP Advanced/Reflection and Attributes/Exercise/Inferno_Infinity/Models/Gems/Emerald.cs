using System;
using System.Collections.Generic;
using System.Text;
using Inferno_Infinity.Contracts;

namespace Inferno_Infinity.Models.Gems
{
    public class Emerald : Gem
    {
        public Emerald(LevelOfClarity levelOfClarity) : base(new Stats(1, 4, 9), levelOfClarity) { }
    }
}
