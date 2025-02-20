using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_17_iterator_basics.Interfaces;

namespace behavioral_17_iterator_basics.Models
{
    public class BookIterator : IIterator<string>
    {
        private readonly List<string> _books;
        private int _index = 0;
        public BookIterator(List<string> books)
        {
            _books = books;
        }
        public bool HasNext()
        {
            return _index < _books.Count;
        }

        public string Next()
        {
            return _books[_index++];
        }
    }
}