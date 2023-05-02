using BookBorrowing.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Service
{
    public class BookService
    {
        public RepositoryBook _RepositoryBook { get; set; }

        public BookService()
        {
            _RepositoryBook = new RepositoryBook();
        }
    }
}
