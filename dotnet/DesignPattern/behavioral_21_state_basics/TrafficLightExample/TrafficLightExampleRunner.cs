using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_21_state_basics.TrafficLightExample.Good;

namespace behavioral_21_state_basics.TrafficLightExample
{
    public class TrafficLightExampleRunner
    {
        public static void Run()
        {
            var trafficLight = new TrafficLight();
            trafficLight.Change();
            trafficLight.Change();
            trafficLight.Change();
            trafficLight.Change();
            trafficLight.Change();
        }
    }
}