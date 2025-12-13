using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{

    [Authorize(Roles = $"{Roles.User},{Roles.Writer}")]

    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
