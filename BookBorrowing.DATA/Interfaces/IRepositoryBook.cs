using BookBorrowing.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Interfaces
{
    public interface IRepositoryBook : IRepositoryModel<Book>
    {
    }
}
