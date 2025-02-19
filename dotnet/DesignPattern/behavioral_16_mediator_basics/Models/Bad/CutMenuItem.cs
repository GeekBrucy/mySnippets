using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_16_mediator_basics.Models.Bad
{
    public class CutMenuItem
    {
        TextArea textArea;
        ClipBoard clipBoard;
        ToolBarButton toolBarButton;

        public void Click()
        {
            string text = textArea.SelectedText();
            textArea.RemoveSelectionText();
            clipBoard.SetData(text);

            toolBarButton.EnabledPasteButton(true);
        }
    }
}