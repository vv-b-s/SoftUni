namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var unitInstance = Activator.CreateInstance(Type.GetType("_03BarracksFactory.Models.Units." + unitType)) as IUnit;

            return unitInstance;
        }
    }
}
