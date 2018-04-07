using System;
using Twitter.App.Model;

namespace Twitter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleWrapper();
            var server = new Server();

            var oven = new MicrowaveOven(server, console);

            var tweet = new Tweet(oven);
            tweet.RetrieveMessage("Hello world!");
        }
    }
}
