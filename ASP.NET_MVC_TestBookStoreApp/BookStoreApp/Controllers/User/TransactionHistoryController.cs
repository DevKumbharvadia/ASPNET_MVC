using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers.User
{
    public class TransactionHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
