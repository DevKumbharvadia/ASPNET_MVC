using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Models.Domain;
using System.Threading.Tasks;
using BookStoreApp.Data;
using BookStoreApp.Models.ViewModel.AddRequest;
using BookStoreApp.Models.ViewModel.EditRequest;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string path = "~/Views/Admin/Authors/";

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(path + "Index.cshtml", await _context.Authors.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(path + "Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAuthorRequest atr)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(new Author { Name = atr.Name });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(path + "Create.cshtml", atr);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(path + "Edit.cshtml", author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAuthorRequest aer)
        {
            if (ModelState.IsValid)
            {
                var author = await _context.Authors.FindAsync(aer.Id);
                if (author == null)
                {
                    return NotFound();
                }

                author.Name = aer.Name;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(path + "Edit.cshtml", aer);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(path + "Details.cshtml", author);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(path + "Delete.cshtml", author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
