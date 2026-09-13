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
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string path = "~/Views/Admin/Publishers/";

        public PublishersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(path + "Index.cshtml", await _context.Publishers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(path + "Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddPublisherRequest apr)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Add(new Publisher { Name = apr.Name });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(path + "Create.cshtml", apr);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(path + "Edit.cshtml", publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPublisherRequest epr)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Find(epr.Id).Name = epr.Name;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(path + "Edit.cshtml", epr);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(path + "Details.cshtml", publisher);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(path + "Delete.cshtml", publisher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
