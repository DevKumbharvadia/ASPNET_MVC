using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models.Domain;
using BookStoreApp.Data;
using BookStoreApp.Models.ViewModel.AddRequest;
using BookStoreApp.Models.ViewModel.EditRequest;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string path = "~/Views/Admin/Categories/";

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        [HttpGet]
        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(path + "Index.cshtml", category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View(path + "Create.cshtml");
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddCategoryRequest acr)
        {
            _context.Categories.Add(new Category { Name = acr.Name });
            _context.SaveChanges();
            return RedirectToAction(nameof(Create));
        }

        // GET: Category/Edit/5
        public IActionResult Edit(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(path + "Edit.cshtml", category);
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
            return View(path + "Edit.cshtml", ecr);
        }

        // GET: Category/Delete/5
        public IActionResult Delete(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(path + "Delete.cshtml", category);
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
            return View(path + "Details.cshtml", category);
        }
    }
}
