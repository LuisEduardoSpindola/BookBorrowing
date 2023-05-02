using BookBorrowing.DATA.Interfaces;
using BookBorrowing.DATA.Models;

namespace BookBorrowing.DATA.Repositories
{
    public class RepositoryBook : RepositoryBase<Book>, IRepositoryBook
    {
        public RepositoryBook(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
