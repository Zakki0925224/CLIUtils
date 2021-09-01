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

                var cmdParams = input.Split(' ');
                var name = cmdParams[0];

                var cmdFound = false;

                foreach (var command in Commands)
                {
                    if (command.Name == name)
                    {
                        cmdFound = true;
                        var args = new List<string>();

                        for (var i = 0; i < cmdParams.Length; i++)
                        {
                            if (i == 0)
                                continue;

                            args.Add(cmdParams[i]);
                        }

                        command.Arguments = args.ToArray();
                        command.ExecuteAction();
                        break;
                    }

                    if (name == "help") // reserved word
                    {
                        cmdFound = true;

                        foreach (var cmd in Commands)
                            Console.WriteLine($"{cmd.Name} - {cmd.Description}");

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
