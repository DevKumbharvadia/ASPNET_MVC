using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers.User
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
