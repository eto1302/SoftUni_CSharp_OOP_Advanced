using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenClosedAndLiskov.Models;
using OpenClosedAndLiskov.Models.Contracts;
using OpenClosedAndLiskov.Models.Factories;

namespace OpenClosedAndLiskov
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();

            ErrorFactory errorFactory = new ErrorFactory();

            Engine engine = new Engine(logger, errorFactory);

            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            LayoutFactory layoutFactory = new LayoutFactory();

            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory appenderFactory  = new AppenderFactory(layoutFactory);
            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                string[] args = Console.ReadLine().Split();
                string errorLevel = "INFO";
                if (args.Length == 3)
                {
                    errorLevel = args[2];

                }

                IAppender appender = appenderFactory.CreateAppender(args[0], errorLevel, args[1]);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);
            return logger;
        }
    }
}