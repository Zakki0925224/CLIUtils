using System;
using System.Collections.Generic;

namespace CLIUtils
{
    public static class CLI
    {
        /// <summary>
        /// String displayed before the main loop starts
        /// </summary>
        public static string StartMessage { get; set; } = "Hello World!";

        /// <summary>
        /// The character string displayed at the user's input position
        /// </summary>
        public static string InputMarker { get; set; } = ">";

        /// <summary>
        /// Whether to insert a line feed code after executing the command
        /// </summary>
        public static bool InsertNewLineAtEndOfExecution { get; set; } = true;
        private static Action<string> RuntimeAction { get; set; }
        private static List<Command> Commands { get; set; } = new List<Command>();

        /// <summary>
        /// Register the command name and its action
        /// </summary>
        /// <param name="name">Command name</param>
        /// <param name="description">It is displayed in the command list of help commands</param>
        /// <param name="action">Actions with space-separated user input values</param>
        public static void RegisterCommand(string name, string description, Action<string[]> action)
        {
            var cmd = new Command(name, description, action);
            Commands.Add(cmd);
        }

        /// <summary>
        /// This action is executed unconditionally when the command is executed
        /// </summary>
        /// <param name="action">Actions with user input values as arguments</param>
        public static void RegisterRuntimeAction(Action<string> action)
        {
            RuntimeAction = action;
        }

        /// <summary>
        /// Infinite console loop
        /// </summary>
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

                if (RuntimeAction != null)
                    RuntimeAction(input);
            }
        }
    }
}
