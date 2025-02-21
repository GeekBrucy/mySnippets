using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_19_chain_of_responsibility_basics.Models.Bad
{
    public abstract class BaseHandler
    {
        public abstract bool CanHandleRequest();
        public abstract void HandleRequest(string req);
    }
}