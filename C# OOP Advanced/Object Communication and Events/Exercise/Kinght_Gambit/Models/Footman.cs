using Kinght_Gambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinght_Gambit.Models
{
    public class Footman : MortalEntity
    {
        public Footman(string name) : base(name, 2) { }

        public override void HandleAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
