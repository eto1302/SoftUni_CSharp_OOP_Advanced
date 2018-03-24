using System;
using OpenClosedAndLiskov.Models.Contracts;

namespace OpenClosedAndLiskov
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Message { get; }

        
    }
}