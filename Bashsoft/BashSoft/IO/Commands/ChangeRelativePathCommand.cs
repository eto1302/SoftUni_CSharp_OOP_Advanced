using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("cdrel")]
    class ChangeRelativePathCommand : Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;
        public ChangeRelativePathCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
                throw new InvalidCommandException(this.Input);
            this.InputOutputManager.ChangeCurrentDirectoryRelative(this.Data[1]);
        }
    }
}
