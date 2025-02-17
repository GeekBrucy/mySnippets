using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_14_command_basics.Models.Good
{
    public class Document
    {
        public void RedoTexts()
        {
            Console.WriteLine("Document Redo");
        }

        public virtual void ShowTexts()
        {
            Console.WriteLine("Document Show");
        }

        public void UndoTexts()
        {
            Console.WriteLine("Document Undo");
        }
    }
}