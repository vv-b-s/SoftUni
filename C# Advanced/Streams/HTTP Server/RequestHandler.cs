using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace HTTP_Server
{
    class RequestHandler
    {
        private static Dictionary<string, FileInfo> siteMap = new Dictionary<string, FileInfo>()
        {
            { "/",new FileInfo(@"Views\index.html") },
            { "/info",new FileInfo(@"Views\info.html") },
            { "error", new FileInfo(@"Views\error.html")}
        };

        /// <summary>
        /// Reads the request from the client and parses the urn
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string ReadRequest(NetworkStream stream)
        {
            var buffer = new byte[4096];

            stream.Read(buffer, 0, buffer.Length);
            var request = new string(Encoding.Default.GetChars(buffer));

            Console.WriteLine("Getting client request");
            var urn = Regex.Match(request, @"(\/.*)\sHTTP").Groups[1].Value;

            return urn;
        }

        /// <summary>
        /// Receive the Universal Resource Name and display the assosiated contents
        /// </summary>
        /// <param name="urn"></param>
        /// <param name="stream"></param>
        public static void Get(string urn, NetworkStream stream)
        {
            Console.WriteLine("Sending the responce.");

            //Find the associated file
            FileInfo renderFile;
            if (siteMap.ContainsKey(urn))
                renderFile = siteMap[urn];
            else
                renderFile = siteMap["error"];

            WriteResponse(renderFile, stream);
        }

        /// <summary>
        /// Renders the HTML file to the given network stream
        /// </summary>
        /// <param name="renderFile"></param>
        /// <param name="networkStream"></param>
        private static void WriteResponse(FileInfo renderFile, NetworkStream networkStream)
        {
            var buffer = new byte[4096];

            //Add this header to the html files in order to make the content show in all browserss
            var httpOk = Encoding.Default.GetBytes("HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\n".ToCharArray());

            using (var renderFileStream = new FileStream(renderFile.FullName, FileMode.Open))
            {
                try
                {
                    //Write the httpOk message
                    networkStream.Write(httpOk, 0, httpOk.Length);

                    //Write the html content
                    int readBytes;
                    while ((readBytes = renderFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        networkStream.Write(buffer, 0, readBytes);
                }
                //A bodge, I know... :(
                catch (IOException)
                {
                    Console.WriteLine("IO Exception handled.");
                }
            }


            Console.WriteLine("Responce sent to client");
        }
    }
}
