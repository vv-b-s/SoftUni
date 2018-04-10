using Kinght_Gambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinght_Gambit.Models
{
    public class King : Entity, IAttackable
    {
        public King(string name) : base(name) { }

        public event AttackHandler AttackEntity;

        public void Attack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            OnAttack(new EventArgs());
        }

        protected void OnAttack(EventArgs args)
        {
            if(AttackEntity != null)
                this.AttackEntity(this, args);
        }
    }
}
