namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
            var performerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == "Performer");

            var performer = Activator.CreateInstance(performerType,name,age) as IPerformer;

            return performer;
        }
	}
}