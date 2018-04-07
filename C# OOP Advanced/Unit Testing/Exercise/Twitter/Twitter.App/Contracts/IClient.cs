using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.App.Contracts
{
    public interface IClient
    {
        IServer Server { get; }
        IConsole Console { get; }

        void PrintAndSendToServer(ITweet tweet);
        void WriteMessageToConsole(ITweet tweet);
        void SendMessageToServer(ITweet tweet);
    }
}
