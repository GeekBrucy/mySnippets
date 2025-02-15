using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_11_flyweight_basics.Models.Good
{
    public static class FontFactory
    {
        private static readonly Hashtable fontTable = new Hashtable();

        public static Font GetFont(Font font)
        {
            if (fontTable.ContainsKey(font))
            {
                Console.WriteLine("Font already exists, returning existing font.");
                return (Font)fontTable[font];
            }
            else
            {
                Console.WriteLine("Adding new font to hash table");
                fontTable.Add(font, font);

                return font;
            }
        }
    }
}