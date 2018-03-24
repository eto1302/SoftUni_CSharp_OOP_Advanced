using System;
using System.Collections.Generic;
using System.Text;
using OpenClosedAndLiskov.Models.Contracts;

namespace OpenClosedAndLiskov.Models
{
    public class ConsoleAppender: IAppender
    {
        

        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public ILayout Layout { get; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);

            Console.WriteLine(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string result =
                $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.MessagesAppended.ToString()}";
            return result;
        }
    }
}
