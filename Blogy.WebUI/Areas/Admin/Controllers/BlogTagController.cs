using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.BlogTagServices;
using Blogy.Business.Services.TagServices;
using Blogy.DataAccess.Repositories.BlogTagRepositories;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class BlogTagController(IBlogTagService _blogTagService,IBlogService _blogService,ITagService _tagService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var values = await _blogTagService.GetAllAsync();
            return View(values);
        }
        public async Task<IActionResult> GetTagsByBlogIdAsync(int blogId)
        {
            var tags = await _blogTagService.GetTagsByBlogIdAsync(blogId);
            return View(tags);
        }


        [HttpGet]
        public async Task<IActionResult> AssignBlogTag(int blogId)
        {
            
            var allTags = await _tagService.GetAllAsync();
            var blogTags = await _blogTagService.GetTagsByBlogIdAsync(blogId);

            var assignTagList = new List<AssignTagDto>();

            foreach (var tag in allTags)
            {
                assignTagList.Add(new AssignTagDto
                {
                    TagId = tag.Id,
                    TagName = tag.Name,
                    BlogId = blogId,
                    TagExists = blogTags.Any(x => x.Id == tag.Id)

                });
            }

            return View(assignTagList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignBlogTag(List<AssignTagDto> model)
        {
            var blogId = model.First().BlogId;
            var existingTags = await _blogTagService.GetTagsByBlogIdAsync(blogId);

            foreach (var item in model)
            {
                bool existsInDb = existingTags.Any(x => x.Id == item.TagId);

               
                if (item.TagExists && !existsInDb)
                {
                    await _blogTagService.AddTagToBlogAsync(blogId, item.TagId);
                }

                if (!item.TagExists && existsInDb)
                {
                    await _blogTagService.RemoveTagFromBlogAsync(blogId, item.TagId);
                }
            }

            return RedirectToAction("Index");
        }


    }
}
