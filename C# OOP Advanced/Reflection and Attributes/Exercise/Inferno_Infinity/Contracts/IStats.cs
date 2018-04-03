using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public interface IStats
    {
        double Strength { get; }
        double Agility { get; }
        double Vitality { get; }

        void GroupIncrease(double amount);
        void GroupDecrease(double amount);
    }
}
