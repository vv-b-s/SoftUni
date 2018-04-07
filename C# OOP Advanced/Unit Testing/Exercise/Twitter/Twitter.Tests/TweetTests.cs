using Moq;
using NUnit.Framework;
using System;
using Twitter.App.Contracts;
using Twitter.App.Model;

namespace Twitter.Tests
{
    [TestFixture]
    public class TweetTests
    {
        private const string DefaultTestMessage = "test";

        private Mock<IClient> clientMock;
        private Tweet defaultTweet;

        [SetUp]
        public void Init()
        {
            clientMock = new Mock<IClient>();
            clientMock.Setup(c => c.PrintAndSendToServer(It.IsAny<Tweet>())).Verifiable();


            this.defaultTweet = new Tweet(clientMock.Object);
        }

        [Test]
        public void TweetGetsRetrieved()
        {
            this.defaultTweet.RetrieveMessage(DefaultTestMessage);

            Assert.That(this.defaultTweet.Message, Is.EqualTo(DefaultTestMessage));
        }

        [Test]
        public void TweetGetsSentToTheServer()
        {
            this.defaultTweet.RetrieveMessage(DefaultTestMessage);

            this.clientMock.Verify();
        }
    }
}
