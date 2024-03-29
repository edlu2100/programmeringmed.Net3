using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using programmeringmed.Net3.Data;
using programmeringmed.Net3.Models;

namespace programmeringmed.Net3.Controllers
{
    public class BorrowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Borrow
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Borrows.Include(b => b.Book).Include(b => b.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Borrow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowModel = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowModel == null)
            {
                return NotFound();
            }

            return View(borrowModel);
        }

        // GET: Borrow/Create
        public IActionResult Create()
        {
            ViewBag.Persons = _context.Persons.ToList(); // Skicka med alla personer med namn
            ViewBag.Books = _context.Books.ToList(); // Skicka med alla böcker med titel
            return View();
        }

        // POST: Borrow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,PersonId,BorrowDate")] BorrowModel borrowModel)
        {
            if (ModelState.IsValid)
            {
                // Hämta den aktuella boken från databasen
                var book = await _context.Books.FindAsync(borrowModel.BookId);

                // Kontrollera om boken finns
                if (book != null)
                {
                    // Minska Quantity med 1
                    book.Quantity -= 1;

                    // Spara ändringarna till databasen
                    _context.Update(book);
                }

                // Lägg till det nya lånet i databasen
                _context.Add(borrowModel);

                // Spara ändringarna i databasen
                await _context.SaveChangesAsync();

                // Omdirigera till Index-åtgärden
                return RedirectToAction(nameof(Index));
            }

            // Om modellens tillstånd inte är giltigt, returnera vyn med felmeddelanden
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", borrowModel.BookId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName", borrowModel.PersonId);
            return View(borrowModel);
        }

        // GET: Borrow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowModel = await _context.Borrows.FindAsync(id);
            if (borrowModel == null)
            {
                return NotFound();
            }

            // Hämta alla personer och böcker för dropdown-listorna
            var persons = await _context.Persons.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.FirstName} {p.LastName}"
            }).ToListAsync();

            var books = await _context.Books.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Title
            }).ToListAsync();

            // Skapa SelectList för personer och böcker
            ViewBag.Persons = new SelectList(persons, "Value", "Text", borrowModel.PersonId);
            ViewBag.Books = new SelectList(books, "Value", "Text", borrowModel.BookId);

            return View(borrowModel);
        }
        // POST: Borrow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,PersonId,BorrowDate")] BorrowModel borrowModel)
        {
            if (id != borrowModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowModelExists(borrowModel.Id))
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
            return View(borrowModel);
        }

        private bool BorrowModelExists(int id)
        {
            throw new NotImplementedException();
        }


        // GET: Borrow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var borrowModel = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            var borrowModels = await _context.Borrows.FindAsync(id);
            if (borrowModel == null)
            {
                return NotFound();
            }

            // Hämta alla personer och böcker för dropdown-listorna
            var persons = await _context.Persons.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.FirstName} {p.LastName}"
            }).ToListAsync();

            var books = await _context.Books.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Title
            }).ToListAsync();

            // Skapa SelectList för personer och böcker
            ViewBag.Persons = new SelectList(persons, "Value", "Text", borrowModel.PersonId);
            ViewBag.Books = new SelectList(books, "Value", "Text", borrowModel.BookId);

            return View(borrowModels);
        }

        // POST: Borrow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowModel = await _context.Borrows.FindAsync(id);
            if (borrowModel != null)
            {
                // Retrieve the associated book
                var book = await _context.Books.FindAsync(borrowModel.BookId);
                if (book != null)
                {
                    // Increment the quantity by 1
                    book.Quantity += 1;
                    _context.Update(book);
                }

                // Remove the borrow
                _context.Borrows.Remove(borrowModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
