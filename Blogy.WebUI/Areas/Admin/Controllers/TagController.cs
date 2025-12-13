using Blogy.Business.DTOs.SocialDtos;
using Blogy.Business.DTOs.TagDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.TagServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class TagController(ITagService _tagService,IBlogService _blogService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var values = await _tagService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTag()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagDto createTagDto)
        {
         
   
            await _tagService.CreateAsync(createTagDto);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateTag(int id)
        {


            var value = _tagService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTag(UpdateTagDto updateTagDto)
        {

            await _tagService.UpdateAsync(updateTagDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteAsync(id);
            return RedirectToAction("Index");


        }
    }
}
