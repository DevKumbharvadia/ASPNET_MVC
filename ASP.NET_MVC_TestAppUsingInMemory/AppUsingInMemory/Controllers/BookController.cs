using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppUsingInMemory.Context;
using AppUsingInMemory.Models;
using System.Linq;

namespace AppUsingInMemory.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Book
        [HttpGet]
        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Category).ToList();
            return View(books);
        }

        // GET: Book/Details/5
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = _context.Categories.ToList(); // For dropdown in view
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddBookRequest abr)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(new Book { Author = abr.Author, CategoryId = abr.CategoryId, Title = abr.Title});
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = _context.Categories.ToList();
            return View("Details");
        }

        // GET: Book/Edit/5
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            ViewData["Categories"] = _context.Categories.ToList(); // For dropdown in view
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, EditBookRequest ebr)
        {
            if (id != ebr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _context.Books.Find(id).Author = ebr.Author;
                _context.Books.Find(id).Title = ebr.Title;
                _context.Books.Find(id).CategoryId = ebr.CategoryId;

                _context.SaveChanges();

                
                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = _context.Categories.ToList();
            return View(ebr);
        }

        // GET: Book/Delete/5
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
