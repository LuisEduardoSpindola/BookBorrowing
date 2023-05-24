using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Service;
using BookBorrowing.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowing.Web.Controllers
{
    public class BorrowingController : Controller
    {
        private ViewBorrowingService _BorrowingService = new ViewBorrowingService();
        


        //Create
        public IActionResult Create() 
        {
            BorrowingViewModel _BorrowingViewModel = new BorrowingViewModel();
            List<Book> _BookList = _BorrowingService._RepositoryBook.GetAll();
            List<Client> _ClientList = _BorrowingService._RepositoryClient.GetAll();


            _BorrowingViewModel._ClientList = _ClientList;
            _BorrowingViewModel._BookList = _BookList;

            _BorrowingViewModel._Borrowing = new Borrowing();
            _BorrowingViewModel._Borrowing.BorrowingDate = DateTime.Now;
            _BorrowingViewModel._Borrowing.DevolutionDate = DateTime.Now.AddDays(7);

            return View(_BorrowingViewModel);
        }


        [HttpPost]
        public IActionResult Create(Borrowing _Borrowing) 
        {
            _BorrowingService._RepositoryBorrowing.Create(_Borrowing);

            if(!ModelState.IsValid) 
            {
                return View();
            }

            return RedirectToAction("List");
        }


        // List
        public IActionResult List()
        {
            List<ViewBorrowing> listViewBorrowing = _BorrowingService._RepositoryViewBorrowing.GetAll();
            return View(listViewBorrowing);
        }

        // Update

        public IActionResult Edit(int id)
        {
            Borrowing _Borrowing = new Borrowing();
            BorrowingViewModel _BorrowingViewModel = new BorrowingViewModel();

            _BorrowingViewModel._BookList = _BorrowingService._RepositoryBook.GetAll();
            _BorrowingViewModel._ClientList = _BorrowingService._RepositoryClient.GetAll();

            _Borrowing = _BorrowingService._RepositoryBorrowing.GetById(id);
            _BorrowingViewModel._Borrowing = _Borrowing;

            return View(_BorrowingViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BorrowingViewModel _BorrowingViewModel)
        {
            _BorrowingService._RepositoryBorrowing.Update(_BorrowingViewModel._Borrowing);

            if (!ModelState.IsValid)
            {
                _BorrowingViewModel._BookList = _BorrowingService._RepositoryBook.GetAll();
                _BorrowingViewModel._ClientList = _BorrowingService._RepositoryClient.GetAll();
                return View(_BorrowingViewModel);
            }

            return RedirectToAction("List");
        }


    }
}
