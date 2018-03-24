using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedAndLiskov.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel Level, string Message)
        {
            this.Level = Level;
            this.DateTime = dateTime;
            this.Message = Message;
        }

        public ErrorLevel Level { get; }
        public DateTime DateTime { get; }
        public string Message { get; }

    }
}
