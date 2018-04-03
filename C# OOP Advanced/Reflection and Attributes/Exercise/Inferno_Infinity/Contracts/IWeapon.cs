using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public enum LevelOfRarity { Common = 1, Uncommon, Rare, Epic = 5 }
    public interface IWeapon
    {
        string Name { get; }
        double MinDmg { get; }
        double MaxDmg { get; }
        int MaxNumberOfSockets { get; }
        LevelOfRarity RarityLevel { get; }
        IReadOnlyCollection<IGem> Gems { get; }

        void AddGem(IGem gem, int index);
        void RemoveGem(int index);
    }
}
