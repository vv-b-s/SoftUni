using Kinght_Gambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinght_Gambit.Models
{
    public class RoyalGuard : MortalEntity
    {
        public RoyalGuard(string name) : base(name, 3) { }

        public override void HandleAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
