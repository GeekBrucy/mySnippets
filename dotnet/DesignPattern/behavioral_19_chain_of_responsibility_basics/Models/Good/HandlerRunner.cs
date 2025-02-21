using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_19_chain_of_responsibility_basics.Models.Good
{
    public class HandlerRunner
    {
        public static void Run(BaseHandlerGood handler)
        {
            handler.HandleRequest("request");
        }
    }
}