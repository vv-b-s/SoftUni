using System;
using System.Collections.Generic;
using System.Text;
using Twitter.App.Contracts;

namespace Twitter.App.Model
{
    public class Tweet : ITweet
    {
        public Tweet(IClient client)
        {
            this.Client = client;
        }

        public string Message { get; private set; }

        public IClient Client { get; }

        public void RetrieveMessage(string message)
        {
            this.Message = message;
            this.Client.PrintAndSendToServer(this);
        }
    }
}
