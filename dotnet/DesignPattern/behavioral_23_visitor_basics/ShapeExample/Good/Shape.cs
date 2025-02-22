using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_23_visitor_basics.ShapeExample.Good
{
    public abstract class Shape
    {
        public abstract void Draw();
        public abstract void Accept(ShapeVisitor visitor);
    }
}