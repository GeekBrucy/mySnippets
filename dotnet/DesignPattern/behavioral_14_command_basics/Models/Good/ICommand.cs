using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_14_command_basics.Models.Good
{
    public interface ICommand
    {
        void Show();
        void Undo();
        void Redo();
    }
}