using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Service
{
    public class ViewBorrowingService
    {
        public RepositoryViewBorrowing _RepositoryViewBorrowing { get; set; } 
        public RepositoryBook _RepositoryBook { get; set; }
        public RepositoryClient _RepositoryClient { get; set; }
        public RepositoryBorrowing _RepositoryBorrowing { get; set; }

        public ViewBorrowingService()
        {
            _RepositoryViewBorrowing = new RepositoryViewBorrowing();
            _RepositoryBook = new RepositoryBook();
            _RepositoryClient = new RepositoryClient();
            _RepositoryBorrowing = new RepositoryBorrowing();
        }
    }
}
