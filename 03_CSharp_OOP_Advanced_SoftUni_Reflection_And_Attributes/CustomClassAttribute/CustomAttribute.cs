using System;
using System.Collections.Generic;
using System.Text;

namespace CustomClassAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, string revision, string description, string[] reviewers)
        {
            this.author = author;
            this.revision = revision;
            this.description = description;
            this.reviewers = reviewers;
        }
        public string author { get; private set; }
        public string revision { get; private set; }
        public string description { get; private set; }
        public string[] reviewers { get; private set; }


    }
}
