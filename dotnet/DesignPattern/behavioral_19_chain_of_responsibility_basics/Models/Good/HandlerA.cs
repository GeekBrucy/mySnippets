using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_19_chain_of_responsibility_basics.Models.Good
{
    public class HandlerA : BaseHandlerGood
    {
        public HandlerA(BaseHandlerGood next) : base(next)
        {
        }

        public override bool CanHandleRequest()
        {
            throw new NotImplementedException();
        }

        public override void HandleRequest(string req)
        {
            if (CanHandleRequest())
            {
                // do stuff
            }
            else
            {
                // let the base class handle the request
                // which is the next handler in the chain
                base.HandleRequest(req);
            }
        }
    }
}