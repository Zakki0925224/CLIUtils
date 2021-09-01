using System;

namespace CLIUtils
{
    public class Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Arguments { get; set; }
        public Action<string[]> Action { get; set; }

        public Command(string name, string description, Action<string[]> action)
        {
            this.Name = name;
            this.Description = description;
            this.Action = action;
        }

        public void ExecuteAction()
        {
            this.Action(this.Arguments);
        }
    }
}