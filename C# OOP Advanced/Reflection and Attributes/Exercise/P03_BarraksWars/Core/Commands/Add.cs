using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Add : Command
    {
        /// <summary>
        /// Adds new unit to the existing units
        /// </summary>
        /// <param name="data"></param>
        /// <param name="repository"></param>
        /// <param name="unitFactory"></param>
        public Add(string[] data) : base(data) { }

        [Inject("IRepository")]
        public IRepository Repository { get; private set; }

        [Inject("IUnitFactory")]
        public IUnitFactory UnitFactory { get; private set; }

        public override string Execute()
        {
            string unitType = Data[0];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
