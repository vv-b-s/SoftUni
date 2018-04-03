using System;
using System.Collections.Generic;
using System.Text;
using Inferno_Infinity.Contracts;

namespace Inferno_Infinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(LevelOfClarity levelOfClarity) : base(new Stats(7, 2, 5), levelOfClarity) { }
    }
}
