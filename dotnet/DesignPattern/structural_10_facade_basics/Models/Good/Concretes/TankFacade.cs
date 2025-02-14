using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_10_facade_basics.Models.Good.Concretes
{
    public class TankFacade
    {
        Wheel[] wheels = new Wheel[4];
        Engine[] engines = new Engine[4];
        Body body = new Body();
        Controller controller = new Controller();
        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void Run()
        {

        }

        public void Shot()
        {

        }
    }
}