namespace _03BarracksFactory.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Gunner : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 20;

        public Gunner() : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
