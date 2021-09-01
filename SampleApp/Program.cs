using System;
using CLIUtils;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI.StartMessage = "Welcome!";
            CLI.RegisterCommand("test", "test command", new string[]{}, () =>
            {
                Console.WriteLine("executed!!!!!!!!");
            });

            CLI.StartMainLoop();
        }
    }
}
