using Kinght_Gambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinght_Gambit.Models
{
    public delegate void KillEventHandler(object sender, EventArgs args);
    public abstract class MortalEntity : Entity, IAttackHandler
    {
        private int health;

        public event KillEventHandler KillEvent;


        protected MortalEntity(string name, int health) : base(name)
        {
            this.health = health;
        }

        public bool IsAlive => this.health > 0;

        public void Kill()
        {
            this.health--;
            OnKill(new EventArgs());
        }

        public abstract void HandleAttack(object sender, EventArgs e);

        protected void OnKill(EventArgs e)
        {
            this.KillEvent(this, e);
        }
    }
}
