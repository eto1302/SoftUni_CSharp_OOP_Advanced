using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;

namespace BashSoft
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }
        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            commandName = commandName.ToLower();
            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
                
            }
            catch (ArgumentNullException ae)
            {
                OutputWriter.DisplayException(ae.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                OutputWriter.DisplayException(dnfe.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }

        }

        /*private IExecutable ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {

                case "open":
                    return new OpenFileCommand(input, data);

                case "mkdir":
                    return new MakeDirectoryCommand(input, data);
                case "help":
                    return new GetHelpCommand(input, data);
                case "ls":
                    return new TraverseFoldersCommand(input, data);

                case "cmp":
                    return new CompareFilesCommand(input, data);

                case "cdrel":
                    return new ChangeRelativePathCommand(input, data);

                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data);

                case "readdb":
                    return new ReadDatabaseCommand(input, data);
                case "display":
                    return new DisplayCommand(input, data);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data);
                case "show":
                    return new ShowCourseCommand(input, data);
                case "dropdb":
                    return new DropDatabaseCommand(input, data);
                default:
                    throw new InvalidCommandException(input);

            }
        }*/
        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = new object[]
            {
                input, data
            };
            Type typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.GetCustomAttributes(typeof(AliasAttribute))
                                            .Where(atr => atr.Equals(command))
                                            .ToArray().Length > 0);
            Type typeOfInterpreter = typeof(CommandInterpreter);
            Command exe = (Command) Activator.CreateInstance(typeOfCommand, parametersForConstruction);
            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter =
                typeOfInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter.First(x => x.FieldType == fieldOfCommand.FieldType).GetValue(this));

                    }
                }
            }
            return exe;
        }
    }
}
