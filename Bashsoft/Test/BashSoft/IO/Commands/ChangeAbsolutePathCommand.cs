using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("cdabs")]
    class ChangeAbsolutePathCommand : Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;
        public ChangeAbsolutePathCommand(string input, string[] data) : base(input, data)

        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            
                this.InputOutputManager.ChangeCurrentDirectoryAbsolute(this.Data[1]);
            
        }
    }
}
