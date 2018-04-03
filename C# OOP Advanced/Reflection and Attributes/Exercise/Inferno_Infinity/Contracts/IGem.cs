using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public enum LevelOfClarity { Chipped = 1, Regular = 2, Perfect = 5, Flawless = 10 }
    public interface IGem
    {
        LevelOfClarity LevelOfClarity { get; }
        IStats Stats { get; }
    }
}
