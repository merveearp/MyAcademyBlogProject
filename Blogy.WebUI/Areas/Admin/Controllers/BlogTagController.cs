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

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    public class BlogTagController(IBlogTagService _blogTagService,IBlogService _blogService,ITagService _tagService) : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = $"{Roles.Admin}")]

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

        public async Task<IActionResult> AssignRoleBlogTagAsync(int blogId)
        {
            var blog = await _blogService.GetByIdAsync(blogId);
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



    }
}
