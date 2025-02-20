using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_17_iterator_basics.Interfaces
{
    public interface IIterableCollection<T>
    {
        IIterator<T> GetIterator();
    }
}