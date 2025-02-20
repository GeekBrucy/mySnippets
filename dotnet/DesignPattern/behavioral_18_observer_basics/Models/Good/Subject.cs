using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.Good
{
    public abstract class Subject
    {
        List<IAccountObserver> _observers = new List<IAccountObserver>();

        public void AddObserver(IAccountObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IAccountObserver observer)
        {
            _observers.Remove(observer);
        }

        public virtual void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(new UserAccountArgs { Message = message });
            }
        }
    }
}