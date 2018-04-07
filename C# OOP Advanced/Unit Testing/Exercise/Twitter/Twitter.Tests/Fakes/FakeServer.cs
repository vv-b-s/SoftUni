using System;
using System.Collections.Generic;
using System.Text;
using Twitter.App.Contracts;

namespace Twitter.Tests.Fakes
{
    public class FakeServer : IServer
    {
        public ITweet Tweet { get; set; }

        public void SendToServer(ITweet tweet)
        {
            this.Tweet = tweet;
        }
    }
}
