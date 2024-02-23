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
    public class BookCategoriesController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BookCategoriesController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: BookCategories
        public async Task<IActionResult> Index()
        {
              return _context.BookCategory != null ? 
                          View(await _context.BookCategory.ToListAsync()) :
                          Problem("Entity set 'BookStoreDbContext.BookCategory'  is null.");
        }

        // GET: BookCategories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory
                .FirstOrDefaultAsync(m => m.Drama == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // GET: BookCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Drama,Friction,Comedy")] BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategory);
        }

        // GET: BookCategories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory.FindAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        // POST: BookCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Drama,Friction,Comedy")] BookCategory bookCategory)
        {
            if (id != bookCategory.Drama)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoryExists(bookCategory.Drama))
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
            return View(bookCategory);
        }

        // GET: BookCategories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory
                .FirstOrDefaultAsync(m => m.Drama == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // POST: BookCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BookCategory == null)
            {
                return Problem("Entity set 'BookStoreDbContext.BookCategory'  is null.");
            }
            var bookCategory = await _context.BookCategory.FindAsync(id);
            if (bookCategory != null)
            {
                _context.BookCategory.Remove(bookCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoryExists(string id)
        {
          return (_context.BookCategory?.Any(e => e.Drama == id)).GetValueOrDefault();
        }
    }
}
