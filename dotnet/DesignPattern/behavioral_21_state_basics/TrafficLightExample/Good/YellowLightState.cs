using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_21_state_basics.TrafficLightExample.Good
{
    public class YellowLightState : ITrafficLightState
    {
        public void Change(TrafficLight context)
        {
            Console.WriteLine("Yellow → Red");
            context.SetState(new RedLightState());
        }
    }
}