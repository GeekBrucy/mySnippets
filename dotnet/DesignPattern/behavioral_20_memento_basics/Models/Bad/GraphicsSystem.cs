using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_20_memento_basics.Models.Bad
{
    public class GraphicsSystem
    {
        Rectangle _r = new Rectangle(10, 10, 100, 100);
        Rectangle _rSaved = new Rectangle(10, 10, 100, 100);
        public void Process()
        {
            _rSaved = (Rectangle)_r.Clone();
        }

        public void Saved_Click()
        {
            _r.SetValue(_rSaved);
        }
    }
}