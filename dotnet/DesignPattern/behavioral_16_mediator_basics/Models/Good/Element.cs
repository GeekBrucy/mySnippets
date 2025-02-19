using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_16_mediator_basics.Models.Good
{
    public abstract class Element
    {
        protected Mediator _mediator;
        public Element(Mediator mediator)
        {
            _mediator = mediator;
            _mediator.AddElement(this);
        }
        public virtual void OnChange()
        {
            _mediator.Notify();
        }
    }
}