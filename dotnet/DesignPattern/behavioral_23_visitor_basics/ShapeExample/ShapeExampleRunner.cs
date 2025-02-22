using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_23_visitor_basics.ShapeExample.Good;

namespace behavioral_23_visitor_basics.ShapeExample
{
    public class ShapeExampleRunner
    {
        public static void Run()
        {
            ShapeVisitor visitor = new MyVisitor();
            var line = new Line();
            line.Accept(visitor);

            var rectangle = new Rectangle();
            rectangle.Accept(visitor);
        }
    }
}