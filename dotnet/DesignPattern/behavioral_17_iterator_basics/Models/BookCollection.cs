using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_17_iterator_basics.Interfaces;

namespace behavioral_17_iterator_basics.Models
{
    public class BookCollection : IIterableCollection<string>
    {
        private readonly List<string> _books = new List<string>();
        public void AddBook(string book)
        {
            _books.Add(book);
        }
        public IIterator<string> GetIterator()
        {
            return new BookIterator(_books);
        }
    }
}