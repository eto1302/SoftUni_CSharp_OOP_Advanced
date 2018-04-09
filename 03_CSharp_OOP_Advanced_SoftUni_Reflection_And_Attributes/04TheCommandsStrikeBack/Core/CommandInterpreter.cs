using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using TheCommandsStrikeBack.Contracts;
using TheCommandsStrikeBack.Core.Commands;

namespace TheCommandsStrikeBack.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1);
            string fullCommandName = commandName + "Command";
            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == fullCommandName);
            return (IExecutable) Activator.CreateInstance(commandType,
                new object[] {data, this.repository, this.unitFactory});
        }
        
    }
}
