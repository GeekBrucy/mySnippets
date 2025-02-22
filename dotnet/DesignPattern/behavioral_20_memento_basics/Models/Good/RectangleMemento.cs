using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_20_memento_basics.Models.Good
{
    public class RectangleMemento
    {
        internal int _x;
        internal int _y;
        internal int _width;
        internal int _height;

        internal void SetState(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
    }
}