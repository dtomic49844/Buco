using Microsoft.AspNetCore.Mvc;

namespace Buco.Controllers
{
    public class NotAuthorizedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}