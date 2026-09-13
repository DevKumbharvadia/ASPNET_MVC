using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models.Domain;
using BookStoreApp.Data;
using BookStoreApp.Models.ViewModel.AddRequest;
using BookStoreApp.Models.ViewModel.EditRequest;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class TagsController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string path = "~/Views/Admin/Tags/";

        public TagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tag = _context.Tags.ToList();
            return View(path+"Index.cshtml", tag);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View(path+"Create.cshtml");
        }

        // POST: Tags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTagRequest tag)
        {
            if (ModelState.IsValid)
            {
                _context.Tags.Add(new Tag { Name = tag.Name });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(tag);
        }

        // GET: Tags/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(path + "Edit.cshtml", tag);
        }

        // POST: Tags/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditTagRequest tag)
        {

            if (ModelState.IsValid)
            {
                _context.Tags.Find(tag.Id).Name = tag.Name;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // GET: Tags/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(path + "Details.cshtml", tag);
        }

        // GET: Tags/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(path + "Delete.cshtml", tag);
        }

        // POST: Tags/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(Guid id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}
