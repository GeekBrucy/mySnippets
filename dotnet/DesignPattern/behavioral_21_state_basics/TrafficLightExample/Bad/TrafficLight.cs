using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_21_state_basics.TrafficLightExample.Bad
{
    public class TrafficLight
    {
        public string CurrentState { get; private set; } = "Red";

        public void Change()
        {
            if (CurrentState == "Red")
            {
                Console.WriteLine("Red → Green");
                CurrentState = "Green";
            }
            else if (CurrentState == "Green")
            {
                Console.WriteLine("Green → Yellow");
                CurrentState = "Yellow";
            }
            else if (CurrentState == "Yellow")
            {
                Console.WriteLine("Yellow → Red");
                CurrentState = "Red";
            }
        }
    }
}