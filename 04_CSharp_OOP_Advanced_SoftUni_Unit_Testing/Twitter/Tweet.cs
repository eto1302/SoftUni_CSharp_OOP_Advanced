using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter
{
    public class Tweet : ITweet
    {
        private IClient client;

        public Tweet(IClient client)
        {
            this.client = client;
        }

        public void ReceiveTweet(string message)
        {
            this.client.WriteTweet(message);
            this.client.SendTweetToServer(message);
        }
    }
}
