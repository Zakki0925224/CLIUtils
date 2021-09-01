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

            CLI.RegisterCommand("test", "test command", () =>
            {
                Console.WriteLine("executed!!!!!!!!");
            });

            CLI.RegisterCommand("exit", "exit app", () =>
            {
                Environment.Exit(0);
            });

            CLI.StartMainLoop();
        }
    }
}
