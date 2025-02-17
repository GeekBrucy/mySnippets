using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_14_command_basics.Models.Good
{
    public class DocumentCommand : ICommand
    {
        private readonly Document _doc;

        public DocumentCommand(Document doc)
        {
            _doc = doc;
        }
        public void Redo()
        {
            _doc.RedoTexts();
        }

        public void Show()
        {
            _doc.ShowTexts();
        }

        public void Undo()
        {
            _doc.UndoTexts();
        }
    }
}