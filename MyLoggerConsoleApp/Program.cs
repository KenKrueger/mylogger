using MyLoggerSerilogAdapter;
using Serilog;
using System;
using MyLogger;
using MyLoggerLog4NetAdapter;
using MyLoggerNlogAdapter;
using NLog.Targets;
using NLog.Conditions;
using NLog.Config;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace MyLoggerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger<Program>();

            logger.WriteWithLog4Net("Hello from log4net");
            logger.WriteWithNLog("Hello from nlog");
            logger.WriteWithSerilog("Hello from serilog");

            var simpleInjectorExample = ContainerHelper.Container.GetInstance<SimpleInjectorExample>();
            simpleInjectorExample.Log("Hello {Name} from Serilog", "Ken");

            var simpleInjectorExample2 = ContainerHelper.Container.GetInstance<SimpleInjectorExample>();
            simpleInjectorExample2.Log("Hello {Name} from Serilog", "Ken");

            Console.ReadKey();
        }  
    }
}
