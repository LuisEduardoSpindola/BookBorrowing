using BookBorrowing.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Service
{
    public class BorrowingService
    {
        public RepositoryBorrowing _RepositoryBorrowing { get; set; }

        public BorrowingService()
        {
            _RepositoryBorrowing = new RepositoryBorrowing();
        }
    }
}
