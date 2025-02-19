using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_16_mediator_basics.Models.Good
{
    public abstract class Mediator
    {
        List<Element> elements = new List<Element>();
        public void AddElement(Element element)
        {
            elements.Add(element);
        }
        public abstract void Notify();
    }
}