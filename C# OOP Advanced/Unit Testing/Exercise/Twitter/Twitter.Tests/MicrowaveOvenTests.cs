using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Twitter.App.Model;
using Twitter.Tests.Fakes;

namespace Twitter.Tests
{
    [TestFixture]
    public class MicrowaveOvenTests
    {
        private Tweet defaultTweet;
        
        private FakeConsole fakeConsole;
        private FakeServer fakeServer;

        private MicrowaveOven oven;

        [SetUp]
        public void Init()
        {
            this.fakeConsole = new FakeConsole();
            this.fakeServer = new FakeServer();

            this.oven = new MicrowaveOven(fakeServer, fakeConsole);

            this.defaultTweet = new Tweet(oven);
            defaultTweet.RetrieveMessage("Hello world!");
        }

        [Test]
        public void MicrowaveOvenShouldSendMessageToConsole()
        {
            this.oven.WriteMessageToConsole(this.defaultTweet);

            var messageOnConsole = fakeConsole.Message;

            Assert.That(messageOnConsole, Is.EqualTo(defaultTweet.Message));
        }

        [Test]
        public void MicrowaveOvenShouldSendMessageToServer()
        {
            this.oven.SendMessageToServer(this.defaultTweet);

            var messageOnServer = this.fakeServer.Tweet;

            Assert.That(this.defaultTweet, Is.EqualTo(messageOnServer));
        }
    }
}
