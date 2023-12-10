using Data;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalApiController : ControllerBase
    {

        private readonly AppDbContext _context;


        public RentalApiController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult GetRentalsByName(string? q)
        {
            return Ok(
                q == null
                ?
                _context.Rentals
                .Select(o => new { name = o.RentalName, id = o.Id })
                .ToList()
                :
                _context.Rentals
                .Where(o => o.RentalName.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new { name = o.RentalName, id = o.Id })
                .ToList()
                );
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = _context.Rentals.Find(id);
            if (rental == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(rental);
            }
        }

    }
}
