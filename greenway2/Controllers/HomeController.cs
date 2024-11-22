using Microsoft.AspNetCore.Mvc;
using greenway2.ViewModels;

namespace greenway2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Message = "Greenway"
            };
            return View(model);
        }
    }
}
