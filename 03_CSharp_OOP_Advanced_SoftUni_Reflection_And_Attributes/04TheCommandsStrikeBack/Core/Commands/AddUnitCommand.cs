using System;
using System.Collections.Generic;
using System.Text;
using TheCommandsStrikeBack.Contracts;

namespace TheCommandsStrikeBack.Core.Commands
{
    public class AddUnitCommand : Command
    {
        public AddUnitCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
