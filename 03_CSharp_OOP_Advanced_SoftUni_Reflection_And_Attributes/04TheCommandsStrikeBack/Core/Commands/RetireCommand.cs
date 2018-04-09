using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TheCommandsStrikeBack.Contracts;

namespace TheCommandsStrikeBack.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            try
            {
                this.Repository.RemoveUnit(this.Data[1]);
                return $"{this.Data[1]} retired!";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
