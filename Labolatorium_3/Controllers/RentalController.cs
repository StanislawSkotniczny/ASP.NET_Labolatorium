using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;

namespace Laboratorium_3.Controllers
{
    public class RentalController : Controller
    {
        private readonly AppDbContext _context;

        public RentalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Rental
        public async Task<IActionResult> Index()
        {
              return _context.Rentals != null ? 
                          View(await _context.Rentals.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Rentals'  is null.");
        }

        // GET: Rental/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rentalEntity = await _context.Rentals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalEntity == null)
            {
                return NotFound();
            }

            return View(rentalEntity);
        }

        // GET: Rental/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentalName,Description")] RentalEntity rentalEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalEntity);
        }

        // GET: Rental/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rentalEntity = await _context.Rentals.FindAsync(id);
            if (rentalEntity == null)
            {
                return NotFound();
            }
            return View(rentalEntity);
        }

        // POST: Rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentalName,Description")] RentalEntity rentalEntity)
        {
            if (id != rentalEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalEntityExists(rentalEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rentalEntity);
        }

        // GET: Rental/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rentalEntity = await _context.Rentals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalEntity == null)
            {
                return NotFound();
            }

            return View(rentalEntity);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rentals == null)
            {
                return Problem("Entity set 'AppDbContext.Rentals'  is null.");
            }
            var rentalEntity = await _context.Rentals.FindAsync(id);
            if (rentalEntity != null)
            {
                _context.Rentals.Remove(rentalEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalEntityExists(int id)
        {
          return (_context.Rentals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
