using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowing.Web.Controllers
{
    public class BorrowingController : Controller
    {

        BorrowingService _BorrowingService = new BorrowingService();

        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Borrowing BorrowingAttribute)
        {
            Borrowing _BorrowingAttribute = _BorrowingService._RepositoryBorrowing.Create(BorrowingAttribute);
            return RedirectToAction("List");
        }

        //List
        public IActionResult List()
        {
            List<Borrowing> _BorrowingList = _BorrowingService._RepositoryBorrowing.GetAll();
            return View(_BorrowingList);
        }

        //Update
        public ActionResult Edit(int id)
        {
            Borrowing _BorrowingEdit = _BorrowingService._RepositoryBorrowing.GetById(id);
            return View(_BorrowingEdit);
        }

        [HttpPost]
        public IActionResult Edit(Borrowing BorrowingInput)
        {
            _BorrowingService._RepositoryBorrowing.Update(BorrowingInput);
            return RedirectToAction("List", new { });
        }

        //Delete
        public IActionResult Delete(int id)
        {
            _BorrowingService._RepositoryBorrowing.DeleteById(id);
            return RedirectToAction("List");
        }

        //Details
        public IActionResult Details(int id)
        {
            Borrowing BorrowingDetails = _BorrowingService._RepositoryBorrowing.GetById(id);
            return View(BorrowingDetails);
        }
    }
}
