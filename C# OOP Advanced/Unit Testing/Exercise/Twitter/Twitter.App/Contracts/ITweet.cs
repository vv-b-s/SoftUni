using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.App.Contracts
{
    public interface ITweet
    {
        IClient Client { get; }
        string Message { get; }

        void RetrieveMessage(string message);
    }
}
