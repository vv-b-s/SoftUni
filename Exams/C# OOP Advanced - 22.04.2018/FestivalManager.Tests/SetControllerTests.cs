// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;
    using System.Text;

    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private IInstrument[] instruments;
        private IPerformer performer;
        private ISong song;
        private ISet set;

        private SetController setController;

        [SetUp]
        public void Init()
        {
            this.stage = new Stage();

            this.instruments = new IInstrument[]
            {
                new Guitar(),
                new Drums(),
                new Microphone()
            };

            this.performer = new Performer("Gosho", 150);
            this.song = new Song("True", new System.TimeSpan(0, 10, 0));

            this.setController = new SetController(stage);
        }

        [Test]
        public void SetControllerPerfosmSetsWearsDownInstruments()
        {
            foreach (var instrument in instruments)
                performer.AddInstrument(instrument);

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);

            this.set = new Long("Reeeeeeeeeeeeeeee...");
            this.set.AddSong(song);
            this.set.AddPerformer(performer);

            this.stage.AddSet(set);

            var initialInstrumentWearLevel = instruments.Select(i => i.Wear).ToArray();

            this.setController.PerformSets();

            var actualWearLevel = instruments.Select(i => i.Wear).ToArray();

            for (int i = 0; i < instruments.Length; i++)
            {
                Assert.That(actualWearLevel[i], Is.LessThan(initialInstrumentWearLevel[i]));
            }
        }

        [Test]
        public void SetControllerDoesNotWearDownSetWithNoSongs()
        {
            foreach (var instrument in instruments)
                performer.AddInstrument(instrument);

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);

            this.set = new Long("Reeeeeeeeeeeeeeee...");
            this.set.AddPerformer(performer);
            this.stage.AddSet(set);

            var initialInstrumentWearLevel = instruments.Select(i => i.Wear).ToArray();

            this.setController.PerformSets();

            var actualWearLevel = instruments.Select(i => i.Wear).ToArray();

            for (int i = 0; i < instruments.Length; i++)
            {
                Assert.That(actualWearLevel[i], Is.EqualTo(initialInstrumentWearLevel[i]));
            }
        }

        [Test]
        public void SetControllerDoesNotWearDownSetWithNoArtist()
        {
            foreach (var instrument in instruments)
                performer.AddInstrument(instrument);

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);

            this.set = new Long("Reeeeeeeeeeeeeeee...");
            this.set.AddSong(song);

            this.stage.AddSet(set);

            var initialInstrumentWearLevel = instruments.Select(i => i.Wear).ToArray();

            this.setController.PerformSets();

            var actualWearLevel = instruments.Select(i => i.Wear).ToArray();

            for (int i = 0; i < instruments.Length; i++)
            {
                Assert.That(actualWearLevel[i], Is.EqualTo(initialInstrumentWearLevel[i]));
            }
        }

        [Test]
        public void SetControllerPerformsSetsInTheCorrectOrder()
        {
            var set1 = new Short("Set1");
            var set2 = new Medium("Set2");

            var performer1 = new Performer("Ivan", 20);
            var performer2 = new Performer("Gosho", 24);
            var performer3 = new Performer("Pesho", 19);

            var guitar = new Guitar();
            var drums = new Drums();
            var microphone = new Microphone();

            var song1 = new Song("Song1", new TimeSpan(0, 1, 2));

            performer1.AddInstrument(guitar);
            performer2.AddInstrument(drums);
            performer3.AddInstrument(microphone);

            this.stage.AddPerformer(performer1);
            this.stage.AddPerformer(performer2);
            this.stage.AddPerformer(performer3);

            this.stage.AddSong(song1);

            set1.AddSong(song1);
            set1.AddPerformer(performer2);
            set1.AddPerformer(performer3);

            this.stage.AddSet(set1);
            this.stage.AddSet(set2);

            Assert.That(setController.PerformSets(), Is.EqualTo(this.PerformSets()));
        }

        private string PerformSets()
        {
            var sb = new StringBuilder();

            var setCount = 1;

            var sortedSets = this.stage.Sets
                .OrderByDescending(s => s.ActualDuration)
                .ThenByDescending(s => s.Performers.Count)
                .ToArray();

            foreach (var set in sortedSets)
            {
                sb.AppendLine($"{setCount++}. {set.Name}:");

                var setWasSuccessful = set.CanPerform();

                if (!setWasSuccessful)
                {
                    sb.AppendLine("-- Did not perform");
                    continue;
                }

                var songCount = 1;
                foreach (var song in set.Songs)
                {
                    sb.AppendLine($"-- {songCount++}. {song}");

                    foreach (var performer in set.Performers)
                    {
                        foreach (var instrument in performer.Instruments)
                        {
                            instrument.WearDown();
                        }
                    }
                }

                sb.AppendLine("-- Set Successful");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }
    }

}