using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_16_mediator_basics.Models.Good
{
    public class ToolBarButton : Element
    {
        public ToolBarButton(Mediator mediator) : base(mediator)
        {
        }

        public void Process()
        {
            OnChange();
        }
    }
}