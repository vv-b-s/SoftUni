using Kinght_Gambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinght_Gambit.Models
{
    public abstract class Entity : IEntity
    {
        protected Entity(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
