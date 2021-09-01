using System;

namespace CLIUtils
{
    public class Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Arguments { get; set; }
        public Action Action { get; set; }

        public Command(string name, string description, string[] arguments, Action action)
        {
            this.Name = name;
            this.Description = description;
            this.Arguments = arguments;
            this.Action = action;
        }

        public void ExecuteAction()
        {
            this.Action();
        }
    }
}