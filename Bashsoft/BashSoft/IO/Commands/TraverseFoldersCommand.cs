using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("ls")]
    class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;
        public TraverseFoldersCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            
                int depth = int.Parse(this.Data[1]);
                this.InputOutputManager.TraverseDirectory(depth);
            
           
        }

    }
}
