using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Buco.Models;
using Buco.ViewModels;

namespace Buco.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string msgToDisplay, string goalText, bool goalReached = false,
            bool added = false, bool deleted = false, bool updated = false,
            bool error = false)
        {
            var model = new HomePageViewModel
            {
                MsgToDisplay = msgToDisplay,
                GoalReached = goalReached,
                GoalText = goalText
            };
            model.CrudInfo.Added = added;
            model.CrudInfo.Deleted = deleted;
            model.CrudInfo.Updated = updated;
            model.CrudInfo.Error = error;
            return View(model);
        }

        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
