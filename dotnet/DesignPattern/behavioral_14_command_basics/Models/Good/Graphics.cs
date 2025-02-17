using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_14_command_basics.Models.Good
{
    public class Graphics
    {
        public void RedoGraphics()
        {
            Console.WriteLine("Graphics Redo");
        }

        public virtual void ShowGraphics()
        {
            Console.WriteLine("Graphics Show");
        }

        public void UndoGraphics()
        {
            Console.WriteLine("Graphics Undo");
        }
    }
}