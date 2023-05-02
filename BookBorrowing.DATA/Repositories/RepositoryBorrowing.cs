using BookBorrowing.DATA.Interfaces;
using BookBorrowing.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Repositories
{
    public class RepositoryBorrowing : RepositoryBase<Borrowing>, IRepositoryBorrowing
    {
        public RepositoryBorrowing(bool SaveChanges = true) : base (SaveChanges)
        {

        }
    }
}
