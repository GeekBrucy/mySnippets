using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_14_command_basics.Models.Good
{
    public class GraphicsCommand : ICommand
    {
        private readonly Graphics _graphics;

        public GraphicsCommand(Graphics graphics)
        {
            _graphics = graphics;
        }
        public void Redo()
        {
            _graphics.RedoGraphics();
        }

        public void Show()
        {
            _graphics.ShowGraphics();
        }

        public void Undo()
        {
            _graphics.UndoGraphics();
        }
    }
}