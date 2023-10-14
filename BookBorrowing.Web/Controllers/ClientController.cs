using BookBorrowing.DATA.Models;
using BookBorrowing.DATA.Service;
using BookBorrowing.Web.Constants;
using Microsoft.AspNetCore.Authorization;
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

            ClientInput.ClientName = ClientInput.ClientName.Trim();
            ClientInput.ClientCpf = ClientInput.ClientCpf.Trim();
            ClientInput.Adress = ClientInput.Adress.Trim();
            ClientInput.City = ClientInput.City.Trim();
            ClientInput.CellNumber = ClientInput.CellNumber.Trim();

            _ClientService._RepositoryClient.Create(ClientInput);

            return RedirectToAction("List");
        }

        // List 

        [Authorize(Roles = Roles.Library)]
        public IActionResult List() 
        {
            List<Client> ClientList = _ClientService._RepositoryClient.GetAll();
            return View(ClientList);
        }

        // Edit

        public IActionResult Edit(int id) 
        {

            Client ClientEdit = _ClientService._RepositoryClient.GetById(id);

            ClientEdit.ClientName = ClientEdit.ClientName.Trim();
            ClientEdit.ClientCpf = ClientEdit.ClientCpf.Trim();
            ClientEdit.Adress = ClientEdit.Adress.Trim();
            ClientEdit.City = ClientEdit.City.Trim();
            ClientEdit.CellNumber = ClientEdit.CellNumber.Trim();

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

    }
}
