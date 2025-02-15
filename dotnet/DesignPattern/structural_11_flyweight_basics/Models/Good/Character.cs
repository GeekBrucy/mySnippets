using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_11_flyweight_basics.Models.Good
{
    public class Character
    {
        private Font _f;
        public char C { get; set; }
        public Font Font
        {
            get
            {
                return _f;
            }
            set
            {
                _f = FontFactory.GetFont(value);
            }
        }
    }
}