using Blogy.Business.DTOs.SocialDtos;
using Blogy.Business.Services.SocialServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class SocialController(ISocialService _socialService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _socialService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSocial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateSocialDto createSocialDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createSocialDto);
            }
            await _socialService.CreateAsync(createSocialDto);          
            return RedirectToAction("Index");
        
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocial(int id)
        {
            var value = _socialService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult>UpdateSocial(UpdateSocialDto updateSocialDto)
        {
            if(!ModelState.IsValid)
            {
                return View(updateSocialDto);
            }
            await _socialService.UpdateAsync(updateSocialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSocial(int id)
        {
            await _socialService.DeleteAsync(id);
            return RedirectToAction("Index");


        }
    }
}
