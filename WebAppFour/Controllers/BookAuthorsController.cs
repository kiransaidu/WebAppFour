using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppFour.Data;
using WebAppFour.Models;

namespace WebAppFour.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BookAuthorsController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: BookAuthors
        public async Task<IActionResult> Index()
        {
              return _context.BookAuthor != null ? 
                          View(await _context.BookAuthor.ToListAsync()) :
                          Problem("Entity set 'BookStoreDbContext.BookAuthor'  is null.");
        }

        // GET: BookAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // GET: BookAuthors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,AuthorId")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookAuthor);
        }

        // GET: BookAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor.FindAsync(id);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            return View(bookAuthor);
        }

        // POST: BookAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,AuthorId")] BookAuthor bookAuthor)
        {
            if (id != bookAuthor.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAuthorExists(bookAuthor.BookId))
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
            return View(bookAuthor);
        }

        // GET: BookAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // POST: BookAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookAuthor == null)
            {
                return Problem("Entity set 'BookStoreDbContext.BookAuthor'  is null.");
            }
            var bookAuthor = await _context.BookAuthor.FindAsync(id);
            if (bookAuthor != null)
            {
                _context.BookAuthor.Remove(bookAuthor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAuthorExists(int id)
        {
          return (_context.BookAuthor?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
