using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("cmp")]
    class CompareFilesCommand : Command
    {
        [Inject]
        private IContentComparer Judge; 
        public CompareFilesCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }
            string firstFilePath = this.Data[1];
            string secondFilePath = this.Data[2];
            this.Judge.CompareContent(firstFilePath, secondFilePath);
        }
    }
}
