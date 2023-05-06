using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Service;
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
        public  IActionResult Create(Book BookAttribute) 
        {
            Book _BookAttribute = _BookService._RepositoryBook.Create(BookAttribute);
            return RedirectToAction("List");
        }

        //List
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
        public IActionResult Edit(Book BookInput) 
        {
            _BookService._RepositoryBook.Update(BookInput);
            return RedirectToAction("List", new { });
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
