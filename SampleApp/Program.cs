using System;
using System.Collections.Generic;
using CLIUtils;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHistory = new List<string>();

            CLI.StartMessage = "Welcome!";
            CLI.InputMarker = ">";

            CLI.RegisterRuntimeAction((input) =>
            {
                inputHistory.Add(input);
                NLogService.InfoLog($"Inputted \"{input}\"");
            });

            CLI.RegisterCommand("test", "test command", (_) =>
            {
                Console.WriteLine("executed!!!!!!!!");
            });

            CLI.RegisterCommand("args-test", "args test", (args) =>
            {
                foreach (var arg in args)
                    Console.WriteLine(arg);
            });

            CLI.RegisterCommand("exit", "exit app", (_) =>
            {
                Environment.Exit(0);
            });

            CLI.StartMainLoop();
        }
    }
}
