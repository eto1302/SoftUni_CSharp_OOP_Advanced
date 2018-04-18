using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("quit")]
    class QuitCommand : Command
    {
        
        public QuitCommand(string input, string[] data) : base(input, data)

        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }
            Environment.Exit(0);
        }
    }
}
