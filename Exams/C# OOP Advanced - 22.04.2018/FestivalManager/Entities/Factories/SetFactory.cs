using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var setType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == type);

            var set = Activator.CreateInstance(setType,name) as ISet;

            return set;
        }
	}
}
