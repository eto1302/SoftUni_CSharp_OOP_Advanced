using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("order")]
    class PrintOrderedStudentsCommand : Command
    {
        [Inject]
        private IDatabase Repository;
        public PrintOrderedStudentsCommand(string input, string[] data) : base(input, data)
        {
            
        }

        public override void Execute()
        {
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }
            string courseName = this.Data[1];
            string filter = this.Data[2].ToLower();
            string orderCommand = this.Data[3].ToLower();
            string orderQuantity = this.Data[4].ToLower();
            TryParseParametersForOrderAndTake(orderCommand, orderQuantity, courseName, filter);
        }

        private void TryParseParametersForOrderAndTake(string orderCommand, string orderQuantity, string courseName,
            string filter)
        {
            if (orderCommand == "take")
            {
                if (orderQuantity == "all")
                {
                    this.Repository.OrderAndTake(courseName, filter, null);
                }
                else
                {
                    int studentsToOrder;
                    bool hasParsed = int.TryParse(orderQuantity, out studentsToOrder);
                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, filter, studentsToOrder);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }
    }
}
