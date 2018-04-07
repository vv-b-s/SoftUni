using System;
using System.Collections.Generic;
using System.Text;
using Twitter.App.Contracts;

namespace Twitter.App.Model
{
    public class MicrowaveOven : IClient
    {

        public MicrowaveOven(IServer server, IConsole console)
        {
            this.Server = server;
            this.Console = console;
        }
        public IServer Server { get; }

        public IConsole Console { get; }

        public void PrintAndSendToServer(ITweet tweet)
        {
            this.WriteMessageToConsole(tweet);
            this.SendMessageToServer(tweet);
        }

        public void SendMessageToServer(ITweet tweet)
        {
            this.Server.SendToServer(tweet);
        }

        public void WriteMessageToConsole(ITweet tweet)
        {
            this.Console.Write(tweet.Message);
        }
    }
}
