using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_16_mediator_basics.Models.Bad
{
    public class ToolBarButton
    {
        public void EnabledPasteButton(bool isEnabled)
        {
            Console.WriteLine($"EnabledPasteButton: {isEnabled}");
        }
    }
}