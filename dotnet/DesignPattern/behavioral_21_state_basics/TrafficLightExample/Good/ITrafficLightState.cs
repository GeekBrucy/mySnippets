using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_21_state_basics.TrafficLightExample.Good
{
    public interface ITrafficLightState
    {
        void Change(TrafficLight context);
    }
}