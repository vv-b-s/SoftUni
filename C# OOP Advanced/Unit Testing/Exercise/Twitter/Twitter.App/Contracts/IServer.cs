using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.App.Contracts
{
    public interface IServer
    {
        void SendToServer(ITweet tweet);
    }
}
