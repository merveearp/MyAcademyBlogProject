using Blogy.Business.DTOs.ContactInfoDtos;
using Blogy.Business.Services.ContactInfoServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    public class ContactInfoController(IContactInfoService _contactInfoService) : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = $"{Roles.Admin}")]
        public async Task<IActionResult> Index()
        {
            var value = await _contactInfoService.GetAsync();
            return View(value);
        }

        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var contactInfo = await _contactInfoService.GetAsync();
            return View(contactInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactInfoDto dto)
        {
            await _contactInfoService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

    }
}
