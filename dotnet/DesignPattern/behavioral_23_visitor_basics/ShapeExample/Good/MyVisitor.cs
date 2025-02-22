using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_23_visitor_basics.ShapeExample.Good
{
    public class MyVisitor : ShapeVisitor
    {
        public override void Visit(Rectangle rectangle)
        {
            Console.WriteLine("Visit rectangle");
        }

        public override void Visit(Circle circle)
        {
            Console.WriteLine("Visit circle");
        }

        public override void Visit(Line line)
        {
            Console.WriteLine("Visit line");
        }
    }
}