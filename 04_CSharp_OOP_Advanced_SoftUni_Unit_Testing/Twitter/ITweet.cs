using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter
{
    public interface ITweet
    {
        void ReceiveTweet(string message);
    }
}
