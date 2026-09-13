using Microsoft.AspNetCore.Mvc;
using AppUsingInMemory.Context;
using AppUsingInMemory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppUsingInMemory.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        [HttpGet]
        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddCategoryRequest acr)
        {
                _context.Categories.Add(new Category { Name = acr.Name});
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        // GET: Category/Edit/5
        public IActionResult Edit(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, EditCategoryRequest ecr)
        {
            if (id != ecr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Find(id).Name = ecr.Name;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ecr);
        }

        // GET: Category/Delete/5
        public IActionResult Delete(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _context.Categories.Remove(_context.Categories.Find(id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Category/Details/5
        public IActionResult Details(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
