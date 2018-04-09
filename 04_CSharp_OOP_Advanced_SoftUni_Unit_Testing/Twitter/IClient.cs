using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter
{
    public interface IClient
    {
        void WriteTweet(string message);

        void SendTweetToServer(string message);
    }
}
