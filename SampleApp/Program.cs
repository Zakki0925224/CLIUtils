using System;
using CLIUtils;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI.StartMessage = "Welcome!";
            CLI.InputMarker = "$";

            CLI.RegisterCommand("test", "test command", new string[]{}, () =>
            {
                Console.WriteLine("executed!!!!!!!!");
            });

            CLI.RegisterCommand("exit", "exit app", new string[]{}, () =>
            {
                Environment.Exit(0);
            });

            CLI.StartMainLoop();
        }
    }
}
