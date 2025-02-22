using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_23_visitor_basics.ShapeExample.Bad
{
    public abstract class Shape
    {
        public abstract void Draw();
        public abstract void MoveTo(Point p);

        // 问题: 如果后续还有abstract方法加入, 所有子类都要更改
    }
}