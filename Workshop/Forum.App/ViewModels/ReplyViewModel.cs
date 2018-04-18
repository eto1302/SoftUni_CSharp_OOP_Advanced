using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Contracts.ViewModels
{
    public class ReplyViewModel: ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string content) : base(content)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
