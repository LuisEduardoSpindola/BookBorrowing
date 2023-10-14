using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Service;
using BookBorrowing.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowing.Web.Controllers
{
    public class BookController : Controller
    {
        BookService _BookService = new BookService(); 
        

        //Create
        public IActionResult Create() 
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            book.BookName = book.BookName.Trim();
            book.AuthorName = book.AuthorName.Trim();
            book.PublisherName = book.PublisherName.Trim();
            book.BookEdition = book.BookEdition.Trim();
            book.BookImg = book.BookImg.Trim();

            _BookService._RepositoryBook.Create(book);
            return RedirectToAction("List");
        }

        //List

        [Authorize(Roles = Roles.Library)]
        public  IActionResult List() 
        {
            List<Book> _BookList = _BookService._RepositoryBook.GetAll();
            return View(_BookList);
        }

        //Update
        public  ActionResult Edit(int id) 
        {
            Book _BookEdit = _BookService._RepositoryBook.GetById(id);
            return View(_BookEdit);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            book.BookName = book.BookName.Trim();
            book.AuthorName = book.AuthorName.Trim();
            book.PublisherName = book.PublisherName.Trim();
            book.BookEdition = book.BookEdition.Trim();
            book.BookImg = book.BookImg.Trim();

            _BookService._RepositoryBook.Update(book);
            return RedirectToAction("List");
        }

        //Delete
        public IActionResult Delete(int id) 
        {
            _BookService._RepositoryBook.DeleteById(id);
            return RedirectToAction("List");
        }

        //Details
        public IActionResult Details(int id) 
        {
            Book BookDetails = _BookService._RepositoryBook.GetById(id);
            return View(BookDetails);
        }
    }
}
