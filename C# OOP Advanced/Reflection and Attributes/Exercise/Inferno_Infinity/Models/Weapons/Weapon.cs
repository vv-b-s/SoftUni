using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferno_Infinity.Models.Weapons
{
    [Metadata("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private const double MinDmgBonusFromStr = 2;
        private const double MinDmgBonusFromAgility = 1;

        private const double MaxDmgBonusFromStr = 3;
        private const double MaxDmgBonusFromAgility = 4;

        private IGem[] gems;

        protected Weapon(string name, double minDamage, double maxDamage, int numberOfSockets, LevelOfRarity levelOfRarity)
        {
            this.Name = name;
            this.MinDmg = minDamage * (int)levelOfRarity;
            this.MaxDmg = maxDamage * (int)levelOfRarity;
            this.MaxNumberOfSockets = numberOfSockets;
            this.RarityLevel = levelOfRarity;

            this.gems = new IGem[numberOfSockets];
        }

        public string Name { get; protected set; }

        public double MinDmg { get; protected set; }

        public double MaxDmg { get; protected set; }

        public int MaxNumberOfSockets { get; protected set; }

        public LevelOfRarity RarityLevel { get; protected set; }

        public IReadOnlyCollection<IGem> Gems => this.gems;

        public void AddGem(IGem gem, int index)
        {
            if (!IndexIsValid(index))
                return;

            if (this.gems[index] != null)
                RemoveGem(index);

            this.MinDmg += MinDmgBonusFromStr * gem.Stats.Strength + MinDmgBonusFromAgility * gem.Stats.Agility;
            this.MaxDmg += MaxDmgBonusFromStr * gem.Stats.Strength + MaxDmgBonusFromAgility * gem.Stats.Agility;

            this.gems[index] = gem;
        }

        public void RemoveGem(int index)
        {
            if (!IndexIsValid(index) || this.gems[index] is null)
                return;

            var gem = this.gems[index];
            this.gems[index] = null;

            this.MinDmg -= MinDmgBonusFromStr * gem.Stats.Strength + MinDmgBonusFromAgility * gem.Stats.Agility;
            this.MaxDmg -= MaxDmgBonusFromStr * gem.Stats.Strength + MaxDmgBonusFromAgility * gem.Stats.Agility;
        }

        public override string ToString()
        {
            var strength = this.gems.Where(g => g != null).Sum(g => g.Stats.Strength);
            var agility = this.gems.Where(g => g != null).Sum(g => g.Stats.Agility);
            var vitality = this.gems.Where(g => g != null).Sum(g => g.Stats.Vitality);

            var output = $"{this.Name}: {this.MinDmg}-{this.MaxDmg} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";

            return output;
        }

        private bool IndexIsValid(int index) => index >= 0 && index < MaxNumberOfSockets;
    }
}
