using System;
using System.Collections.Generic;

namespace CLIUtils
{
    public static class CLI
    {
        public static string StartMessage { get; set; } = "Hello World!";
        public static string InputMarker { get; set; } = ">";
        public static bool InsertNewLineAtEndOfExecution { get; set; } = true;
        private static List<Command> Commands { get; set; } = new List<Command>();

        public static void RegisterCommand(string name, string description, Action<string[]> action)
        {
            var cmd = new Command(name, description, action);
            Commands.Add(cmd);
        }

        public static void StartMainLoop()
        {
            Console.WriteLine(StartMessage);
            while(true)
            {
                Console.Write(InputMarker);
                var input = Console.ReadLine();

                if (input == null ||
                    input.Length == 0 ||
                    input == "")
                    continue;

                var cmd = input.Split(' ');
                var name = cmd[0];

                var cmdFound = false;

                foreach (var command in Commands)
                {
                    if (command.Name == name)
                    {
                        cmdFound = true;
                        var args = new List<string>();

                        for (var i = 0; i < cmd.Length; i++)
                        {
                            if (i == 0)
                                continue;

                            args.Add(cmd[i]);
                        }

                        command.Arguments = args.ToArray();
                        command.ExecuteAction();
                        break;
                    }
                }

                if (!cmdFound)
                    Console.WriteLine($"Command \"{name}\" was not found");

                if (InsertNewLineAtEndOfExecution)
                    Console.WriteLine();
            }
        }
    }
}
