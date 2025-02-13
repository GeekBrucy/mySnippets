
using structural_09_decorator_basics.Good.Models.Abstracts;


namespace structural_09_decorator_basics.Good.Models.Concrete
{
    public class T50 : Tank
    {
        public override void Run()
        {
            Console.WriteLine("T75 Run");
        }

        public override void Shot()
        {
            Console.WriteLine("T75 Shot");
        }

    }
}