using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_20_memento_basics.Models.Bad
{
    public class Rectangle : ICloneable
    {
        int _x;
        int _y;
        int _width;
        int _height;
        public Rectangle(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public void SetValue(Rectangle rectangle)
        {
            _x = rectangle._x;
            _y = rectangle._y;
            _width = rectangle._width;
            _height = rectangle._height;
        }

        public void MoveTo(Point point)
        {
            _x = point.X;
            _y = point.Y;
        }

        public void ChangeWidth(int width)
        {
            _width = width;
        }

        public void ChangeHeight(int height)
        {
            _height = height;
        }

        public void Resize(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Rectangle with x={_x}, y={_y}, width={_width}, height={_height}");
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}