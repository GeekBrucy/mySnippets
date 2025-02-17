using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_14_command_basics.Models.Good
{
    public class Application
    {
        Stack<ICommand> stack = new Stack<ICommand>();

        public void Show()
        {
            foreach (ICommand command in stack)
            {
                command.Show();
            }
        }

        public void Undo()
        {
            foreach (ICommand command in stack)
            {
                command.Undo();
            }
        }
        public void Redo()
        {
            foreach (ICommand command in stack)
            {
                command.Redo();
            }
        }
    }
}