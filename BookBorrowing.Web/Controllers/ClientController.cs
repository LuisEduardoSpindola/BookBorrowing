using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowing.Web.Controllers
{
    public class ClientController : Controller
    {
        private ClientService _ClientService = new ClientService();


        // Create
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client ClientInput) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _ClientService._RepositoryClient.Create(ClientInput);

            return RedirectToAction("List");
        }

        // List 

        public IActionResult List() 
        {
            List<Client> ClientList = _ClientService._RepositoryClient.GetAll();
            return View(ClientList);
        }

        // Edit

        public IActionResult Edit(int id) 
        {
            Client ClientEdit = _ClientService._RepositoryClient.GetById(id);
            return View(ClientEdit);
        }

        [HttpPost]
        public IActionResult Edit(Client ClientInput) 
        {
            _ClientService._RepositoryClient.Update(ClientInput);
            return RedirectToAction("List", new { });
        }

        // Delete 

        public IActionResult Delete(int id) 
        {
            _ClientService._RepositoryClient.DeleteById(id);
            return RedirectToAction("List");
        }

        // Details

        public IActionResult Details(int id) 
        {
            Client _ClientDetails = _ClientService._RepositoryClient.GetById(id);
            return View(_ClientDetails); 
        }
    }
}
