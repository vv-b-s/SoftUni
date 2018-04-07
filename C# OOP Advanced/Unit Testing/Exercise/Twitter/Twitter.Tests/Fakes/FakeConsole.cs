using System;
using System.Collections.Generic;
using System.Text;
using Twitter.App.Contracts;

namespace Twitter.Tests.Fakes
{
    class FakeConsole : IConsole
    {
        public string Message { get; set; }

        public void Write(string message)
        {
            this.Message = message;
        }
    }
}
