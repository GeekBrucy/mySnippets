using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_23_visitor_basics.ShapeExample.Bad
{
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw circle");
        }

        public override void MoveTo(Point p)
        {
            Console.WriteLine($"Move to ({p.X}, {p.Y})");
        }
    }
}