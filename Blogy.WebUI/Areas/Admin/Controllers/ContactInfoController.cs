using Blogy.Business.DTOs.ContactInfoDtos;
using Blogy.Business.Services.ContactInfoServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class ContactInfoController(IContactInfoService _contactInfoService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var value = await _contactInfoService.GetAsync();
            return View("Index", value ?? new ResultContactInfoDto());
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var resultDto = await _contactInfoService.GetAsync();

            if (resultDto == null)
                return RedirectToAction(nameof(Index));

            var updateDto = new UpdateContactInfoDto
            {
                Id = resultDto.Id,
                Location = resultDto.Location,
                OpenHours = resultDto.OpenHours,
                Email = resultDto.Email,
                Phone = resultDto.Phone
            };

            return View("Update", updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactInfoDto dto)
        {
            if (!ModelState.IsValid)
                return View("Update", dto);

            await _contactInfoService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


    }
}
