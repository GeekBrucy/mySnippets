using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_19_chain_of_responsibility_basics.Models.Bad
{
    public class BHandler : BaseHandler
    {
        public override bool CanHandleRequest()
        {
            throw new NotImplementedException();
        }

        public override void HandleRequest(string req)
        {
            throw new NotImplementedException();
        }
    }
}