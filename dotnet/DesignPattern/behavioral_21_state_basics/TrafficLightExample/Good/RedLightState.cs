using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_21_state_basics.TrafficLightExample.Good
{
    public class RedLightState : ITrafficLightState
    {
        public void Change(TrafficLight context)
        {
            Console.WriteLine("Red → Green");
            context.SetState(new GreenLightState());
        }
    }
}