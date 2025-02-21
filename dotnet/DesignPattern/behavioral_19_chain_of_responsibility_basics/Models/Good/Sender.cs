using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_19_chain_of_responsibility_basics.Models.Good
{
    public class Sender
    {
        public void Process()
        {
            HandlerA handlerA = new HandlerA(null);
            HandlerB handlerB = new HandlerB(handlerA);
            HandlerC handlerC = new HandlerC(handlerB);

            HandlerRunner.Run(handlerC);
        }
    }
}