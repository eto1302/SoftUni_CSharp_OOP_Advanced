using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedAndLiskov.Models.Contracts
{
    public interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void WriteToFile(string errorLog);
    }
}
