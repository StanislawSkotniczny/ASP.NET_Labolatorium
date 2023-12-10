using Microsoft.AspNetCore.Mvc;
using Laboratorium_3.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Laboratorium_3.Controllers
{
    //[Authorize(Roles = "admin")]
    public class BookController: Controller
    {
        private readonly IBookService _bookService;

        private readonly IDateTimeProvider _dateTimeProvider;

        public BookController(IDateTimeProvider timeProvider, IBookService bookService)
        {
            _dateTimeProvider = timeProvider;
            _bookService = bookService;
        }

        //static int id = 0;
        [AllowAnonymous]
        public IActionResult Index(int page = 1, int size = 5)
        {
            if(size <1)
            {
                return BadRequest();
            }
            return View(_bookService.FindPage(page, size));
            //return View(_bookService.FindAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> rentals = CreateRentalItemList();
            Book model = new Book();
            model.RentalList = rentals;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                // zapisanie modelu do bazy lub kolekcji.
                _bookService.Add(model);
                return RedirectToAction("Index");
            }
            model.RentalList = CreateRentalItemList();
            return View();

           
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _bookService.FindById(id);
            model.RentalList = CreateRentalItemList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (ModelState.IsValid)
            {
                // zapisanie modelu do bazy lub kolekcji
                _bookService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_bookService.FindById(id));
        }


        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _bookService.DeleteById(model.Id);
            return RedirectToAction("Index");
        }



        private List<SelectListItem> CreateRentalItemList()
        {
            var gr = new SelectListGroup() { Name = "Wypożyczono" };
            return _bookService.FindAllRentalsForVieModel()
                .Select(e => new SelectListItem() { Text = e.RentalName, Value = e.Id.ToString(), Group = gr })
                .Append(new SelectListItem() { Text = "Brak organizacji", Value = "", Selected = true, Group = new SelectListGroup() { Name = "Brak" } })
                .ToList();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_bookService.FindById(id));
        }


        [HttpGet]
        public IActionResult CreateApi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateApi(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }






    }
}
