using Microsoft.AspNetCore.Mvc;

namespace B7.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
