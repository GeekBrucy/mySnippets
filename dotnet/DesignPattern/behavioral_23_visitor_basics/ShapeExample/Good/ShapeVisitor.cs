using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_23_visitor_basics.ShapeExample.Good
{
    public abstract class ShapeVisitor
    {
        public abstract void Visit(Rectangle rectangle);
        public abstract void Visit(Circle circle);
        public abstract void Visit(Line line);
    }
}