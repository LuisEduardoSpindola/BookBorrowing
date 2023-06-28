using Microsoft.AspNetCore.Mvc;

namespace BookBorrowing.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
