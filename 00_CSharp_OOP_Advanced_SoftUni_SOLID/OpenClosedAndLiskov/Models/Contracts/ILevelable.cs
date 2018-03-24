using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedAndLiskov.Models.Contracts
{
    public interface ILevelable
    {
        ErrorLevel Level { get; }
    }
}
