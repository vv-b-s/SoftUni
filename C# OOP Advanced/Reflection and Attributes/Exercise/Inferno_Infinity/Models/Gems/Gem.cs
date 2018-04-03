using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        protected Gem(IStats stats, LevelOfClarity levelOfClarity)
        {
            this.Stats = stats;
            Stats.GroupIncrease((int)levelOfClarity);
        }

        public LevelOfClarity LevelOfClarity { get; protected set; }

        public IStats Stats { get; protected set; }
    }
}
