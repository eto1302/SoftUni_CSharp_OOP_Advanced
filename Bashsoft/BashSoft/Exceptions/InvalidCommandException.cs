using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    class InvalidCommandException : Exception
    {

        public InvalidCommandException(string input) : base($"The command '{input}' is invalid!")
        {
            
        }
    }
}
