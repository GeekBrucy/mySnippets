using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_19_chain_of_responsibility_basics.Models.Bad
{
    public class Sender
    {
        public void Process()
        {
            List<BaseHandler> handlers = new List<BaseHandler>
            {
                new AHandler(),
                new BHandler(),
                new CHandler()
            };
            foreach (var handler in handlers)
            {
                if (handler.CanHandleRequest())
                {
                    handler.HandleRequest("Request");
                }
            }
        }

    }
}