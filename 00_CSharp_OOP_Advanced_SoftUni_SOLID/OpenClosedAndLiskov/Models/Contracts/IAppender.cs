using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedAndLiskov.Models.Contracts
{
    public interface IAppender : ILevelable
    {
        ILayout Layout { get; }

        
        void Append(IError error);
    }
}
