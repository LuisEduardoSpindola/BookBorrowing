using BookBorrowing.DATA.Interfaces;
using BookBorrowing.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Repositories
{
    public class RepositoryViewBorrowing : RepositoryBase<ViewBorrowing>, IRepositoryViewBorrowing
    {
        public RepositoryViewBorrowing(bool SaveChanges = true) : base (SaveChanges)
        {

        }
    }
}
