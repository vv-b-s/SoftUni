using System;
using System.Collections.Generic;
using System.Text;
using Inferno_Infinity.Contracts;

namespace Inferno_Infinity.Models.Gems
{
    public class Amethyst : Gem
    {
        public Amethyst(LevelOfClarity levelOfClarity) : base(new Stats(2, 8, 4), levelOfClarity) { }
    }
}
