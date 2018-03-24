using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OpenClosedAndLiskov.Models.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }


        void Log(IError error);
    }
}
