using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_19_chain_of_responsibility_basics.Models.Good
{
    public abstract class BaseHandlerGood
    {
        public BaseHandlerGood(BaseHandlerGood next)
        {
            _next = next;
        }
        public abstract bool CanHandleRequest();
        public virtual void HandleRequest(string req)
        {
            if (Next != null)
            {
                Next.HandleRequest(req);
            }
        }
        private BaseHandlerGood _next;
        public BaseHandlerGood Next
        {
            get { return _next; }
            set { _next = value; }
        }
    }
}