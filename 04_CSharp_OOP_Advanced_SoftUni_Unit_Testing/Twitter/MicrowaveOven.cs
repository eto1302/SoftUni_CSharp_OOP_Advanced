using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Twitter
{
    public class MicrowaveOven : IClient
    {
        private const string ServerFileName = "Server.txt";
        private const string MessageSeparator = "<[<MessageSeparator>]>";
        private readonly string serverFullPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), ServerFileName);

        

        public void WriteTweet(string message)
        {
            Console.WriteLine(message);
        }

        public void SendTweetToServer(string message)
        {

            File.AppendAllText(this.serverFullPath, $"{message}{MessageSeparator}");

        }




    }

}


