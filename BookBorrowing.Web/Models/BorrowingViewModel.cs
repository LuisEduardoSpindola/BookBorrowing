using BookBorrowing.DATA.Models;

namespace BookBorrowing.Web.Models
{
    public class BorrowingViewModel
    {
        public Book _Book { get; set; }

        public Client _Client { get; set; }

        public Borrowing _Borrowing { get; set; }

        public List<Client> _ClientList { get; set; }

        public List<Book> _BookList { get; set; }

        public ViewBorrowing _ViewBorrowing { get; set; }
    }
}
    