using Blogy.Business.DTOs.AIDtos;
using Blogy.Business.DTOs.FooterAboutDtos;
using Blogy.Business.Services.AIServices.ContentService;
using Blogy.DataAccess.Repositories.FooterAboutRepositories;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class FooterAboutController(IFooterAboutService _footerAboutService, IAIContentService _aIContentService) : Controller
        {
            public async Task<IActionResult> Index()
            {

                var footerAbout = await _footerAboutService.GetAsync();
                return View(footerAbout);
            }

            [HttpGet]
            public async Task<IActionResult> Update()
            {
                var footerAbout = await _footerAboutService.GetAsync();
                return View(footerAbout);
            }

            [HttpPost]
            public async Task<IActionResult> Update(UpdateFooterAboutDto dto)
            {
                await _footerAboutService.UpdateAsync(dto);
                return RedirectToAction("Index");
            }

            [HttpPost]
            public async Task<IActionResult> GenerateWithAiAbout(string topic)
            {
                var aiResult = await _aIContentService.CreateAboutAsync(
                    new CreateAIAboutDto { Topic = topic });

                return Json(aiResult.Content);
            }

        
    }
}
