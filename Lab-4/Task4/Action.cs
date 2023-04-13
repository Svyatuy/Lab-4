using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Action
    {
        public string Name { get; set; }

        public Action(string name)
        {
            Name = name;
        }

        public void Execute()
        {
            Console.WriteLine($"Executing action '{Name}'...");
            Console.WriteLine();
        }
    }

    public class ActionEventArgs : EventArgs
    {
        public Action Action { get; set; }

        public ActionEventArgs(Action action)
        {
            Action = action;
        }
    }
}
