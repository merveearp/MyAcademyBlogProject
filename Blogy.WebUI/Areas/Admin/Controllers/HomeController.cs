using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
