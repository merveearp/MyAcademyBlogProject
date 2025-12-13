using Blogy.Business.DTOs.AboutDtos;
using Blogy.Business.Services.AboutServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class AboutController(IAboutService _aboutService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var value = await _aboutService.GetAsync();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAbout)
        {
            await _aboutService.UpdateAsync(updateAbout);
            return View("Index");
        }


    }
}
