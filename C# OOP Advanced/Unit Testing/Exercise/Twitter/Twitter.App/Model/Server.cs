using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Twitter.App.Contracts;

namespace Twitter.App.Model
{
    class Server : IServer
    {
        public void SendToServer(ITweet tweet)
        {
            File.WriteAllLines("tweet.txt", new string[] { tweet.Message });
        }
    }
}
