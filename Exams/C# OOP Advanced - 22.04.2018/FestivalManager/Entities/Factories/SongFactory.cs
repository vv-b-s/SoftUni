namespace FestivalManager.Entities.Factories
{
	using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
            var songType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == "Song");

            var song = Activator.CreateInstance(songType,name,duration) as ISong;

            return song;
        }
	}
}