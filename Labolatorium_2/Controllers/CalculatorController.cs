using Labolatorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_2.Controllers
{

    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }

    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Result([FromQuery(Name = "operator")] Operators? op, double? x, double? y)
        //{
        //    if (op == null || x == null || y == null)
        //    {
        //        return View("Error");
        //    }


        //    double? result = 0;
        //    switch (op)
        //    {
        //        case Operators.SUB:
        //            result = x - y;
        //            break;
        //        case Operators.ADD:
        //            result = x + y;
        //            break;
        //        case Operators.DIV:
        //            result = x / y;
        //            break;
        //        case Operators.MUL:
        //            result = x * y;
        //            break;
        //    }
        //    ViewBag.Result = result;
        //    return View();
        //}


        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }


        public IActionResult Form()
        {
            return View();
        }



    }
}
