using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_23_visitor_basics.ShapeExample.Good
{
    public class Line : Shape
    {
        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Line");
        }
    }
}