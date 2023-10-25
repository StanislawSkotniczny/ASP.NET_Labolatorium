using Microsoft.AspNetCore.Mvc;
using Labolatorium_3_projekt_Book.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Labolatorium_3_projekt_Book.Controllers
{
    public class BookController: Controller
    {
        static Dictionary <int, Book> _books = new Dictionary <int, Book> ();
        static int id = 0;

        public IActionResult Index()
        {
            return View(_books);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                // zapisanie modelu do bazy lub kolekcji.
                model.Id = id++;
                _books[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_books[id]);
        }


        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (ModelState.IsValid)
            {
                // zapisanie modelu do bazy lub kolekcji
                _books[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_books[id]);
        }


        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _books.Remove(model.Id);
            return RedirectToAction("Index");
        }

    
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_books.ContainsKey(id))
            {
                var book = _books[id];
                return View(book);
            }
            return NotFound(); // Jeśli książka o podanym ID nie istnieje
        }




    }
}
