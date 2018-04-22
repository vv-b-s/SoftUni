namespace FestivalManager
{
    using System.IO;
    using System.Linq;
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            var stage = new Stage();

            IFestivalController festivalController = new FestivalController(stage, new SetFactory(), new InstrumentFactory(), new PerformerFactory(), new SongFactory());
            ISetController setController = new SetController(stage);

            var engine = new Engine(new ConsoleReader(), new ConsoleWriter(), festivalController, setController);

            engine.Run();
        }
    }
}