using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]

    public class AdminController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
  