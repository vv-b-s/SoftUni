using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data) : base(data) { }

        [Inject("IRepository")]
        public IRepository Repository { get; private set; }

        public override string Execute()
        {
            var unitType = this.Data[0];
            this.Repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}
