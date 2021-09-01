using System;
using CLIUtils;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI.StartMessage = "Welcome!";
            CLI.InputMarker = ">";

            CLI.RegisterCommand("test", "test command", (args) =>
            {
                Console.WriteLine("executed!!!!!!!!");
            });

            CLI.RegisterCommand("args-test", "args test", (args) =>
            {
                foreach (var arg in args)
                {
                    Console.WriteLine(arg);
                }
            });

            CLI.RegisterCommand("exit", "exit app", (args) =>
            {
                Environment.Exit(0);
            });

            CLI.StartMainLoop();
        }
    }
}
