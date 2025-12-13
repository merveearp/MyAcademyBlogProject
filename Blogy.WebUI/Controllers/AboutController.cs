using Blogy.Business.Services.AboutServices;
using Blogy.DataAccess.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class AboutController(IAboutService _aboutService) : Controller
    {
      
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAsync();
            return View(values);
        }
    }
}
