using System;
using System.Net;
using System.Net.Sockets;

namespace HTTP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = 1337;
            var tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();

            Console.WriteLine($"Listening on port {port}...");

            while(true)
            {
                using (var stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    //Get the request
                    var urn = RequestHandler.ReadRequest(stream);

                    //Send a responce
                    RequestHandler.Get(urn, stream);

                }
            }

        }
    }
}
