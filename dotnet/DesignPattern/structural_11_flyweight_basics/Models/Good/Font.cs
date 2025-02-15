using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_11_flyweight_basics.Models.Good
{
    public class Font
    {
        public Font(string name, int size, Color color)
        {
            Name = name;
            Size = size;
            Color = color;
        }
        public string Name { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Font other)
            {
                return Name == other.Name && Size == other.Size && Color == other.Color;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Size, Color);
        }
    }
}