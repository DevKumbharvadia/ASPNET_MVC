using BookStoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers.User
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = _context.Books.Include(b => b.Author)
                                       .Include(b => b.Publisher)
                                       .Include(b => b.Category);
            return View("~/Views/Coutomers/Index.cshtml", books.ToList()); // Returns a partial view
        }
    }
}
