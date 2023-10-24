using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Labolatorium_3.Models;

namespace Labolatorium_3.Controllers
{
    
    
        public class ContactController : Controller
        {
            static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
            static int id = 0;
            public IActionResult Index()
            {

                return View(_contacts);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Contact model)
            {
                if (ModelState.IsValid)
                {
                    // zapisanie modelu do bazy lub kolekcji
                    model.Id = id++;
                    _contacts[model.Id] = model;
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Update(int id)
            {
                return View(_contacts[id]);
            }
            [HttpPost]
            public IActionResult Update(Contact model)
            {
                if (ModelState.IsValid)
                {
                    // zapisanie modelu do bazy lub kolekcji
                    _contacts[model.Id] = model;
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Delete(int id)
            {
                return View(_contacts[id]);
            }
            [HttpPost]
            public IActionResult Delete(Contact model)
            {
                _contacts.Remove(model.Id);
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_contacts.ContainsKey(id))
            {
                var book = _contacts[id];
                return View(book);
            }
            return NotFound(); // Jeśli książka o podanym ID nie istnieje
        }

    }

}
