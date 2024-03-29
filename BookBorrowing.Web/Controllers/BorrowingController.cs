﻿using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Service;
using BookBorrowing.Web.Constants;
using BookBorrowing.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowing.Web.Controllers
{
    public class BorrowingController : Controller
    {
        private ViewBorrowingService _BorrowingService = new ViewBorrowingService();
        private UserManager<Areas.Identity.Data.Library> _userManager;

        public BorrowingController(UserManager<Areas.Identity.Data.Library> userManager)
        {
            _userManager = userManager;
        }

        //Create
        public IActionResult Create()
        {
            BorrowingViewModel _BorrowingViewModel = new BorrowingViewModel();

            var user = _userManager.GetUserAsync(User).Result;
            string sessionLibraryId = user.Id.ToString();

            // Filtrar a lista de clientes e livros com base no IdLibrary
            List<Client> _ClientList = _BorrowingService._RepositoryClient
                .GetAll()
                .Where(c => c.IdLibrary == sessionLibraryId)
                .ToList();

            List<Book> _BookList = _BorrowingService._RepositoryBook
                .GetAll()
                .Where(b => b.IdLibrary == sessionLibraryId)
                .ToList();

            _BorrowingViewModel._ClientList = _ClientList;
            _BorrowingViewModel._BookList = _BookList;

            _BorrowingViewModel._Borrowing = new Borrowing();
            _BorrowingViewModel._Borrowing.BorrowingDate = DateTime.Now;
            _BorrowingViewModel._Borrowing.DevolutionDate = DateTime.Now.AddDays(7);

            _BorrowingViewModel._Client = new Client();
            _BorrowingViewModel._Book = new Book();

            _BorrowingViewModel._Client.IdLibrary = sessionLibraryId;
            _BorrowingViewModel._Book.IdLibrary = sessionLibraryId;
            _BorrowingViewModel._Borrowing.IdLibrary = sessionLibraryId;

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
        [Authorize(Roles = Roles.Library)]
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

        // Delete 

        public IActionResult Delete(int id) 
        {
            _BorrowingService._RepositoryBorrowing.DeleteById(id);
            return RedirectToAction("List");
        }

        // Details  

        public IActionResult Details(int id)
        {
            Borrowing _Borrowing = _BorrowingService._RepositoryBorrowing.GetById(id);
            BorrowingViewModel _BorrowingViewModel = new BorrowingViewModel();
            _BorrowingViewModel._Borrowing = _Borrowing;

            // Buscar o cliente pelo ID do empréstimo
            Client _Client = _BorrowingService._RepositoryClient.GetById(_Borrowing.IdBorrowingClient);
            _BorrowingViewModel._Client = _Client;

            // Buscar o livro pelo ID do empréstimo
            Book _Book = _BorrowingService._RepositoryBook.GetById(_Borrowing.IdBorrowingBook);
            _BorrowingViewModel._Book = _Book;

            return View(_BorrowingViewModel);
        }



    }
}
