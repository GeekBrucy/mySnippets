using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_14_command_basics.Models.Bad
{
    public class Application
    {
        public void Show()
        {
            Document doc = new Document();
            doc.ShowText();

            Graphics graph = new Graphics();
            graph.ShowGraphics();
        }
    }
}