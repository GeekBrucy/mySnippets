using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_21_state_basics.TrafficLightExample.Good
{
    public class TrafficLight
    {
        private ITrafficLightState _state;

        public TrafficLight()
        {
            _state = new RedLightState(); // Start with Red
        }

        public void SetState(ITrafficLightState state)
        {
            _state = state;
        }

        public void Change()
        {
            _state.Change(this);
        }
    }
}