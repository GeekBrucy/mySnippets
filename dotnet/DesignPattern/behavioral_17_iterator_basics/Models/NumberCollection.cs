using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_17_iterator_basics.Models
{
    public class NumberCollection : IEnumerable<int>
    {
        private readonly List<int> _numbers = new List<int>();
        public void AddNumber(int number)
        {
            _numbers.Add(number);
        }
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var number in _numbers)
            {
                yield return number;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}