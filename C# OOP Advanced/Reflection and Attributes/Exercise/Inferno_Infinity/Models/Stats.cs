using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Models
{
    class Stats : IStats
    {
        private double[] statsArray;

        public Stats(double strength, double agility, double vitality)
        {
            statsArray = new[] { strength, agility, vitality };
        }

        public double Strength
        {
            get => statsArray[0];
            private set => statsArray[0] = value;
        }

        public double Agility
        {
            get => statsArray[1];
            private set => statsArray[1] = value;
        }

        public double Vitality
        {
            get => statsArray[2];
            private set => statsArray[2] = value;
        }

        public void GroupDecrease(double amount)
        {
            for (int i = 0; i < this.statsArray.Length; i++)
                this.statsArray[i] -= amount;
        }

        public void GroupIncrease(double amount)
        {
            for (int i = 0; i < this.statsArray.Length; i++)
                this.statsArray[i] += amount;
        }
    }
}
