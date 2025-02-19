using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_16_mediator_basics.Models.Bad
{
    public class TextArea
    {
        public string SelectedText()
        {
            return "SelectedText";
        }

        public void RemoveSelectionText()
        {
            Console.WriteLine("Remove Selection Text");
        }
    }
}